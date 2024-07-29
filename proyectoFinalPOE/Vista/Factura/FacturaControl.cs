using System;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Forms;
using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Repositorio;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace proyectoFinalPOE.Vista
{
    public partial class FacturaControl : UserControl
    {
        private DatabaseHelper databaseHelper;
        private FacturaRepository facturaRepository;
        private Panel panelVentana;

        public FacturaControl(DatabaseHelper databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            facturaRepository = new FacturaRepository(databaseHelper);
            LoadFacturas();
        }

        private void LoadFacturas()
        {
            DataTable dtFacturas = facturaRepository.GetFacturas();

            if (dtFacturas.Rows.Count > 0)
            {
                dgvFacturas.DataSource = dtFacturas;
                PersonalizarDataGridView();
            }
            else
            {
                MessageBox.Show("No hay facturas disponibles.");
            }
        }

        private void PersonalizarDataGridView()
        {
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvFacturas.AllowUserToResizeColumns = true;
            dgvFacturas.AllowUserToResizeRows = true;
            dgvFacturas.RowHeadersVisible = false;

            // Ocultar las columnas de ID solo si existen
            if (dgvFacturas.Columns.Contains("idFactura"))
                dgvFacturas.Columns["idFactura"].Visible = false;

            if (dgvFacturas.Columns.Contains("idNegocio"))
                dgvFacturas.Columns["idNegocio"].Visible = false;

            if (dgvFacturas.Columns.Contains("idReparacion"))
                dgvFacturas.Columns["idReparacion"].Visible = false;

            if (dgvFacturas.Columns.Contains("idCliente"))
                dgvFacturas.Columns["idCliente"].Visible = false;

            // Configurar los encabezados y el orden de las columnas visibles solo si existen
            if (dgvFacturas.Columns.Contains("Negocio"))
            {
                dgvFacturas.Columns["Negocio"].HeaderText = "Negocio";
                dgvFacturas.Columns["Negocio"].DisplayIndex = 0;
            }

            if (dgvFacturas.Columns.Contains("Reparacion"))
            {
                dgvFacturas.Columns["Reparacion"].HeaderText = "Reparación";
                dgvFacturas.Columns["Reparacion"].DisplayIndex = 1;
            }

            if (dgvFacturas.Columns.Contains("Cliente"))
            {
                dgvFacturas.Columns["Cliente"].HeaderText = "Cliente";
                dgvFacturas.Columns["Cliente"].DisplayIndex = 2;
            }

            if (dgvFacturas.Columns.Contains("Valor"))
            {
                dgvFacturas.Columns["Valor"].HeaderText = "Valor";
                dgvFacturas.Columns["Valor"].DisplayIndex = 3;
            }

            if (dgvFacturas.Columns.Contains("Fecha"))
            {
                dgvFacturas.Columns["Fecha"].HeaderText = "Fecha";
                dgvFacturas.Columns["Fecha"].DisplayIndex = 4;
            }

            if (dgvFacturas.Columns.Contains("Estado"))
            {
                dgvFacturas.Columns["Estado"].HeaderText = "Estado";
                dgvFacturas.Columns["Estado"].DisplayIndex = 5;
            }

            // Agregar columna de botones para eliminar
            if (!dgvFacturas.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                btnEliminar.Name = "btnEliminar";
                dgvFacturas.Columns.Add(btnEliminar);
            }
        }

        private void btnCrearFactura_Click(object sender, EventArgs e)
        {
            NuevaFacturaControl nuevaFacturaControl = new NuevaFacturaControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(nuevaFacturaControl);
            nuevaFacturaControl.Dock = DockStyle.Fill;
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            string clienteBuscado = txtBuscarFactura.Text.Trim();
            if (!string.IsNullOrEmpty(clienteBuscado))
            {
                DataTable dtFacturas = facturaRepository.GetFacturas();
                var facturasFiltradas = dtFacturas.AsEnumerable()
                    .Where(row => row.Field<string>("Cliente").Contains(clienteBuscado, StringComparison.OrdinalIgnoreCase))
                    .CopyToDataTable();

                dgvFacturas.DataSource = facturasFiltradas;
                PersonalizarDataGridView();
            }
            else
            {
                LoadFacturas();
            }
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvFacturas.Columns["btnEliminar"].Index)
            {
                // Confirmar eliminación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta factura?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Obtener el ID de la factura
                    int idFactura = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells["idFactura"].Value);

                    // Eliminar la factura
                    facturaRepository.EliminarFactura(idFactura);

                    // Recargar las facturas
                    LoadFacturas();
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dgvFacturas.Columns["btnDetalle"].Index)
            {
                // Obtener el ID de la factura
                int idFactura = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells["idFactura"].Value);

                // Generar el PDF de la factura
                GenerarPdfFactura(idFactura);
            }
        }




        private void GenerarPdfFactura(int idFactura)
        {
            // Obtener los datos de la factura
            DataTable facturaData = facturaRepository.GetFacturaById(idFactura);

            if (facturaData.Rows.Count == 0)
            {
                MessageBox.Show("Factura no encontrada.");
                return;
            }

            DataRow row = facturaData.Rows[0];

            // Usar un SaveFileDialog para permitir al usuario seleccionar la ubicación donde guardar el archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"Factura_{idFactura}.pdf",
                Title = "Guardar Factura como"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Crear el documento PDF
                iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Agregar contenido al documento
                // Agregar la imagen del logo (ajusta la ruta de la imagen según sea necesario)
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("C:\\Users\\USER\\source\\repos\\proyectoFinalPOE\\proyectoFinalPOE\\Resources\\smartphone_1180304.png");
                logo.ScaleToFit(100, 100);
                logo.Alignment = Element.ALIGN_LEFT;
                document.Add(logo);

                // Agregar información del encabezado
                iTextSharp.text.Paragraph encabezado = new iTextSharp.text.Paragraph("INSTITUTO SUPERIOR TECNOLOGICO LICEO CRISTIANO\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                encabezado.Alignment = Element.ALIGN_CENTER;
                document.Add(encabezado);

                // Crear una tabla para la información de la factura
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1, 2 });

                // Agregar celdas a la tabla
                table.AddCell("R.U.C:");
                table.AddCell("0992880783001");
                table.AddCell("Número de autorización:");
                table.AddCell("001-002-000015616");
                table.AddCell("Fecha y hora de autorización:");
                table.AddCell("19/07/2024 14:56:18");
                table.AddCell("Ambiente:");
                table.AddCell("Producción Emisión: Normal");

                document.Add(table);

                // Agregar información adicional
                iTextSharp.text.Paragraph informacionAdicional = new iTextSharp.text.Paragraph("\nInformación Adicional\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                informacionAdicional.Alignment = Element.ALIGN_LEFT;
                document.Add(informacionAdicional);

                PdfPTable infoAdicionalTable = new PdfPTable(2);
                infoAdicionalTable.WidthPercentage = 100;
                infoAdicionalTable.SetWidths(new float[] { 1, 2 });
                infoAdicionalTable.AddCell("Dirección:");
                infoAdicionalTable.AddCell("CALLE PUBLICA Y AV JUAN TANCA MARENGO KM 4");
                infoAdicionalTable.AddCell("Teléfono:");
                infoAdicionalTable.AddCell("04-2591910");
                infoAdicionalTable.AddCell("Correo:");
                infoAdicionalTable.AddCell("facturacion@tecnologicocristiano.edu.ec");

                document.Add(infoAdicionalTable);

                // Agregar tabla de detalles de la factura
                PdfPTable detalleTable = new PdfPTable(4);
                detalleTable.WidthPercentage = 100;
                detalleTable.SetWidths(new float[] { 1, 4, 1, 1 });

                // Agregar encabezados de la tabla
                detalleTable.AddCell("Cantidad");
                detalleTable.AddCell("Descripción");
                detalleTable.AddCell("Precio Unitario");
                detalleTable.AddCell("Total");

                // Agregar detalles de la factura
                detalleTable.AddCell("1");
                detalleTable.AddCell("Factura Certificado Culminacion de Malla");
                detalleTable.AddCell("10.00");
                detalleTable.AddCell("10.00");

                document.Add(detalleTable);

                // Agregar totales
                PdfPTable totalesTable = new PdfPTable(2);
                totalesTable.WidthPercentage = 50;
                totalesTable.HorizontalAlignment = Element.ALIGN_RIGHT;
                totalesTable.SetWidths(new float[] { 1, 1 });

                totalesTable.AddCell("Subtotal:");
                totalesTable.AddCell("10.00");
                totalesTable.AddCell("IVA 12%:");
                totalesTable.AddCell("1.20");
                totalesTable.AddCell("Total:");
                totalesTable.AddCell("11.20");

                document.Add(totalesTable);

                document.Close();

                MessageBox.Show($"Factura guardada como {filePath}");
            }
        }
    }
    }



