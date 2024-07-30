using proyectoFinalPOE.Repositorio;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Controlador;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class ClienteControl : UserControl
    {
        private ClienteRepository clienteRepository;
        private DatabaseConector databaseHelper;
        private Panel panelVentana;

        public ClienteControl(DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            clienteRepository = new ClienteRepository(databaseHelper);
            LoadClientes();
            AddButtonColumns(); // Asegúrate de agregar las columnas de botones después de cargar los clientes
        }

        private void LoadClientes()
        {
            List<Cliente> clientes = clienteRepository.GetClientes();
            dgvClientes.DataSource = clientes;
            PersonalizarDataGridView();
        }

        private void AddButtonColumns()
        {
            if (!dgvClientes.Columns.Contains("Edit") && !dgvClientes.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true
                };
                dgvClientes.Columns.Add(editButtonColumn);

                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                };
                dgvClientes.Columns.Add(deleteButtonColumn);

                // Ajustar el DisplayIndex de las columnas de botones para que aparezcan al final
                int columnCount = dgvClientes.Columns.Count;
                dgvClientes.Columns["Edit"].DisplayIndex = columnCount - 2;
                dgvClientes.Columns["Delete"].DisplayIndex = columnCount - 1;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarNombre.Text;
            List<Cliente> clientes = clienteRepository.BuscarClientesPorNombre(nombre);
            dgvClientes.DataSource = clientes;
            PersonalizarDataGridView();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            NuevoClienteControl nuevoClienteControl = new NuevoClienteControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(nuevoClienteControl);
            nuevoClienteControl.Dock = DockStyle.Fill;
        }

        private void PersonalizarDataGridView()
        {
            dgvClientes.Columns["IdCliente"].Visible = false;
            dgvClientes.Columns["Nombre"].Visible = false;
            dgvClientes.Columns["Apellido"].Visible = false;
            dgvClientes.Columns["BdEst"].Visible = false;

            dgvClientes.Columns["NombreCompleto"].HeaderText = "Cliente";
            dgvClientes.Columns["NombreCompleto"].DisplayIndex = 0;

            dgvClientes.Columns["NuCedula"].HeaderText = "Cédula";
            dgvClientes.Columns["NuCedula"].Width = 150;
            dgvClientes.Columns["NuCelular"].HeaderText = "Celular";
            dgvClientes.Columns["NuCelular"].Width = 150;
            dgvClientes.Columns["Correo"].HeaderText = "Correo Electrónico";
            dgvClientes.Columns["Correo"].Width = 250;

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvClientes.RowHeadersVisible = false;
        }


        private void txtBuscarNombre_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si el clic fue en una columna de botones
            if (e.RowIndex >= 0) // Evitar que se ejecute cuando se hace clic en el encabezado
            {
                if (e.ColumnIndex == dgvClientes.Columns["Edit"].Index)
                {
                    // Manejar la edición
                    int idCliente = (int)dgvClientes.Rows[e.RowIndex].Cells["IdCliente"].Value;
                    EditarCliente(idCliente);
                }
                else if (e.ColumnIndex == dgvClientes.Columns["Delete"].Index)
                {
                    // Manejar la eliminación
                    int idCliente = (int)dgvClientes.Rows[e.RowIndex].Cells["IdCliente"].Value;
                    EliminarCliente(idCliente);
                }
            }
        }

        private void EditarCliente(int idCliente)
        {
            // Implementar la lógica para editar el cliente
            EditarClienteControl editarClienteControl = new EditarClienteControl(databaseHelper, panelVentana, idCliente);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(editarClienteControl);
            editarClienteControl.Dock = DockStyle.Fill;
        }

        private void EliminarCliente(int idCliente)
        {
            // Implementar la lógica para eliminar el cliente
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                clienteRepository.EliminarCliente(idCliente);
                LoadClientes();
                MessageBox.Show("Cliente eliminado exitosamente.");
            }
        }


    }
}