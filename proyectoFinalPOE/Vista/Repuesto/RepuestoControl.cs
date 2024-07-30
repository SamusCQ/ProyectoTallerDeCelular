using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Repositorio;
using ModeloRepuesto = proyectoFinalPOE.Modelo.Repuesto;

namespace proyectoFinalPOE.Vista.Repuesto
{
    public partial class RepuestoControl : UserControl
    {
        private DatabaseConector databaseHelper;
        private RepuestoRepository repuestoRepository;
        private Panel panelVentana;

        public RepuestoControl(DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            repuestoRepository = new RepuestoRepository(databaseHelper);
            LoadRepuestos();
        }

        private void LoadRepuestos()
        {
            List<proyectoFinalPOE.Modelo.Repuesto> repuestos = repuestoRepository.GetRepuestos();
            dgvRepuestos.DataSource = repuestos;
            PersonalizarDataGridView();
        }

        private void dgvRepuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvRepuestos.Columns["Editar"].Index)
                {
                    int idRepuesto = Convert.ToInt32(dgvRepuestos.Rows[e.RowIndex].Cells["IdRepuesto"].Value);
                    EditarRepuestoControl editarRepuestoControl = new EditarRepuestoControl(idRepuesto, databaseHelper, panelVentana);
                    panelVentana.Controls.Clear();
                    panelVentana.Controls.Add(editarRepuestoControl);
                    editarRepuestoControl.Dock = DockStyle.Fill;
                }
                else if (e.ColumnIndex == dgvRepuestos.Columns["Eliminar"].Index)
                {
                    int idRepuesto = Convert.ToInt32(dgvRepuestos.Rows[e.RowIndex].Cells["IdRepuesto"].Value);
                    repuestoRepository.EliminarRepuesto(idRepuesto);
                    LoadRepuestos();
                }
                else if (e.ColumnIndex == dgvRepuestos.Columns["IngresarCantidad"].Index)
                {
                    int idRepuesto = Convert.ToInt32(dgvRepuestos.Rows[e.RowIndex].Cells["IdRepuesto"].Value);
                    InsertarCantidadControl insertarCantidadControl = new InsertarCantidadControl(idRepuesto, databaseHelper, panelVentana);
                    panelVentana.Controls.Clear();
                    panelVentana.Controls.Add(insertarCantidadControl);
                    insertarCantidadControl.Dock = DockStyle.Fill;
                }
            }
        }

        private void PersonalizarDataGridView()
        {
            // Configura el DataGridView para que no muestre ciertos campos internos
            if (dgvRepuestos.Columns["IdRepuesto"] != null)
            {
                dgvRepuestos.Columns["IdRepuesto"].Visible = false;
            }
            if (dgvRepuestos.Columns["IdMarca"] != null)
            {
                dgvRepuestos.Columns["IdMarca"].Visible = false;
            }
            if (dgvRepuestos.Columns["IdModelo"] != null)
            {
                dgvRepuestos.Columns["IdModelo"].Visible = false;
            }
            if (dgvRepuestos.Columns["BdEst"] != null)
            {
                dgvRepuestos.Columns["BdEst"].Visible = false;
            }
            if (dgvRepuestos.Columns["IdTipo"] != null)
            {
                dgvRepuestos.Columns["IdTipo"].Visible = false;
            }
            if (dgvRepuestos.Columns["FechaIngreso"] != null)
            {
                dgvRepuestos.Columns["FechaIngreso"].Visible = false;
            }

            dgvRepuestos.Columns["Descripcion"].HeaderText = "Descripción";
            dgvRepuestos.Columns["MarcaDescripcion"].HeaderText = "Marca";
            dgvRepuestos.Columns["ModeloDescripcion"].HeaderText = "Modelo";
            dgvRepuestos.Columns["TipoDescripcion"].HeaderText = "Tipo";
            dgvRepuestos.Columns["Valor"].HeaderText = "Valor";
            dgvRepuestos.Columns["Cantidad"].HeaderText = "Cantidad";

            if (!dgvRepuestos.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn editarButton = new DataGridViewButtonColumn
                {
                    Name = "Editar",
                    HeaderText = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true
                };
                dgvRepuestos.Columns.Add(editarButton);
            }

            if (!dgvRepuestos.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn eliminarButton = new DataGridViewButtonColumn
                {
                    Name = "Eliminar",
                    HeaderText = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                };
                dgvRepuestos.Columns.Add(eliminarButton);
            }

            if (!dgvRepuestos.Columns.Contains("IngresarCantidad"))
            {
                DataGridViewButtonColumn ingresarCantidadButton = new DataGridViewButtonColumn
                {
                    Name = "IngresarCantidad",
                    HeaderText = "Ingresar Cantidad",
                    Text = "Ingresar Cantidad",
                    UseColumnTextForButtonValue = true
                };
                dgvRepuestos.Columns.Add(ingresarCantidadButton);
            }

            // Ajustar el tamaño de las columnas para adaptarse al contenido
            foreach (DataGridViewColumn column in dgvRepuestos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Permitir scroll horizontal
            dgvRepuestos.ScrollBars = ScrollBars.Both;
            dgvRepuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRepuestos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRepuestos.RowHeadersVisible = false;
            dgvRepuestos.CellClick += dgvRepuestos_CellClick;
        }

        private void btnCrear_Click_1(object sender, EventArgs e)
        {
            NuevoRepuestoControl nuevoRepuestoControl = new NuevoRepuestoControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(nuevoRepuestoControl);
            nuevoRepuestoControl.Dock = DockStyle.Fill;
        }
    }
}
