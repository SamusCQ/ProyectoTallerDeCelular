using proyectoFinalPOE.Repositorio;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Controlador;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class TecnicoControl : UserControl
    {
        private TecnicoRepository tecnicoRepository;
        private DatabaseConector databaseHelper;
        private Panel panelVentana;

        public TecnicoControl(DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            tecnicoRepository = new TecnicoRepository(databaseHelper);
            LoadTecnicos();
            AddButtonColumns(); // Asegúrate de agregar las columnas de botones después de cargar los técnicos
        }

        private void LoadTecnicos()
        {
            List<Tecnico> tecnicos = tecnicoRepository.GetTecnicos();
            dgvTecnicos.DataSource = tecnicos;
            PersonalizarDataGridView();
        }

        private void AddButtonColumns()
        {
            if (!dgvTecnicos.Columns.Contains("Edit") && !dgvTecnicos.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true
                };
                dgvTecnicos.Columns.Add(editButtonColumn);

                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                };
                dgvTecnicos.Columns.Add(deleteButtonColumn);

                // Ajustar el DisplayIndex de las columnas de botones para que aparezcan al final
                int columnCount = dgvTecnicos.Columns.Count;
                dgvTecnicos.Columns["Edit"].DisplayIndex = columnCount - 2;
                dgvTecnicos.Columns["Delete"].DisplayIndex = columnCount - 1;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarNombre.Text;
            List<Tecnico> tecnicos = tecnicoRepository.BuscarTecnicosPorNombre(nombre);
            dgvTecnicos.DataSource = tecnicos;
            PersonalizarDataGridView();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            NuevoTecnicoControl nuevoTecnicoControl = new NuevoTecnicoControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(nuevoTecnicoControl);
            nuevoTecnicoControl.Dock = DockStyle.Fill;
        }

        private void PersonalizarDataGridView()
        {
            dgvTecnicos.Columns["IdTecnico"].Visible = false;
            dgvTecnicos.Columns["Nombre"].Visible = false;
            dgvTecnicos.Columns["Apellido"].Visible = false;
            dgvTecnicos.Columns["BdEst"].Visible = false;

            dgvTecnicos.Columns["NombreCompleto"].HeaderText = "Técnico";
            dgvTecnicos.Columns["NombreCompleto"].DisplayIndex = 0;

            dgvTecnicos.Columns["NuCedula"].HeaderText = "Cédula";
            dgvTecnicos.Columns["NuCedula"].Width = 150;
            dgvTecnicos.Columns["NuCelular"].HeaderText = "Celular";
            dgvTecnicos.Columns["NuCelular"].Width = 150;
            dgvTecnicos.Columns["Correo"].HeaderText = "Correo Electrónico";
            dgvTecnicos.Columns["Correo"].Width = 250;

            dgvTecnicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTecnicos.RowHeadersVisible = false;
        }

        private void txtBuscarNombre_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void dgvTecnicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si el clic fue en una columna de botones
            if (e.RowIndex >= 0) // Evitar que se ejecute cuando se hace clic en el encabezado
            {
                if (e.ColumnIndex == dgvTecnicos.Columns["Edit"].Index)
                {
                    // Manejar la edición
                    int idTecnico = (int)dgvTecnicos.Rows[e.RowIndex].Cells["IdTecnico"].Value;
                    EditarTecnico(idTecnico);
                }
                else if (e.ColumnIndex == dgvTecnicos.Columns["Delete"].Index)
                {
                    // Manejar la eliminación
                    int idTecnico = (int)dgvTecnicos.Rows[e.RowIndex].Cells["IdTecnico"].Value;
                    EliminarTecnico(idTecnico);
                }
            }
        }

        private void EditarTecnico(int idTecnico)
        {
            // Implementar la lógica para editar el técnico
            EditarTecnicoControl editarTecnicoControl = new EditarTecnicoControl(databaseHelper, panelVentana, idTecnico);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(editarTecnicoControl);
            editarTecnicoControl.Dock = DockStyle.Fill;
        }

        private void EliminarTecnico(int idTecnico)
        {
            // Implementar la lógica para eliminar el técnico
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este técnico?", "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                tecnicoRepository.EliminarTecnico(idTecnico);
                LoadTecnicos();
                MessageBox.Show("Técnico eliminado exitosamente.");
            }
        }
    }
}

