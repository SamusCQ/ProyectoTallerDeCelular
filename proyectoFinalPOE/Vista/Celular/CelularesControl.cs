using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo; // Asegúrate de tener esta directiva
using proyectoFinalPOE.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class CelularesControl : UserControl
    {
        private CelularRepository celularRepository;
        private DatabaseHelper databaseHelper;
        private Panel panelVentana;

        public CelularesControl(DatabaseHelper databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            celularRepository = new CelularRepository(databaseHelper);
            LoadCelulares();
        }

        private void LoadCelulares()
        {
            List<Celular> celulares = celularRepository.GetCelulares();
            dgvCelulares.DataSource = celulares;
            PersonalizarDataGridView();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtBuscarCelular.Text;
            List<Celular> celulares = celularRepository.BuscarCelularesPorNombreCliente(nombreCliente);
            dgvCelulares.DataSource = celulares;
            PersonalizarDataGridView();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            NuevoCelularControl nuevoCelularControl = new NuevoCelularControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(nuevoCelularControl);
            nuevoCelularControl.Dock = DockStyle.Fill;
        }

        private void dgvCelulares_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvCelulares.Columns["Editar"].Index)
                {
                    int idCelular = Convert.ToInt32(dgvCelulares.Rows[e.RowIndex].Cells["IdCelular"].Value);
                    EditarCelularControl editarCelularControl = new EditarCelularControl(idCelular, databaseHelper, panelVentana);
                    panelVentana.Controls.Clear();
                    panelVentana.Controls.Add(editarCelularControl);
                    editarCelularControl.Dock = DockStyle.Fill;
                }
                else if (e.ColumnIndex == dgvCelulares.Columns["Eliminar"].Index)
                {
                    int idCelular = Convert.ToInt32(dgvCelulares.Rows[e.RowIndex].Cells["IdCelular"].Value);
                    celularRepository.EliminarCelular(idCelular);
                    LoadCelulares();
                }
            }
        }

        private void PersonalizarDataGridView()
        {
            // Asegúrate de que las columnas existen antes de intentar acceder a ellas.
            if (dgvCelulares.Columns["IdCelular"] != null)
            {
                dgvCelulares.Columns["IdCelular"].Visible = false;
            }
            if (dgvCelulares.Columns["IdCliente"] != null)
            {
                dgvCelulares.Columns["IdCliente"].Visible = false;
            }
            if (dgvCelulares.Columns["IdModelo"] != null)
            {
                dgvCelulares.Columns["IdModelo"].Visible = false;
            }
            if (dgvCelulares.Columns["IdColor"] != null)
            {
                dgvCelulares.Columns["IdColor"].Visible = false;
            }
            if (dgvCelulares.Columns["IdMarca"] != null)
            {
                dgvCelulares.Columns["IdMarca"].Visible = false;
            }
            if (dgvCelulares.Columns["BdEst"] != null)
            {
                dgvCelulares.Columns["BdEst"].Visible = false;
            }

            dgvCelulares.Columns["NombreCliente"].HeaderText = "Cliente";
            dgvCelulares.Columns["NombreModelo"].HeaderText = "Modelo";
            dgvCelulares.Columns["Color"].HeaderText = "Color";

            // Agregar botones de editar y eliminar si aún no se han agregado
            if (!dgvCelulares.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn editarButton = new DataGridViewButtonColumn
                {
                    Name = "Editar",
                    HeaderText = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true
                };
                dgvCelulares.Columns.Add(editarButton);
            }

            if (!dgvCelulares.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn eliminarButton = new DataGridViewButtonColumn
                {
                    Name = "Eliminar",
                    HeaderText = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                };
                dgvCelulares.Columns.Add(eliminarButton);
            }

            // Ajustar el ancho de las columnas para llenar todo el espacio disponible
            dgvCelulares.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ajustar automáticamente la altura de las filas para mostrar todo el contenido
            dgvCelulares.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvCelulares.RowHeadersVisible = false;
            dgvCelulares.CellClick += dgvCelulares_CellClick;
        }





        private void txtBuscarCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }
    }
}
