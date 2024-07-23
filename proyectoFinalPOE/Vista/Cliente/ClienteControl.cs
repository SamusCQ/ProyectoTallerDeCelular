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
        private DatabaseHelper databaseHelper;
        private Panel panelVentana;

        public ClienteControl(DatabaseHelper databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            clienteRepository = new ClienteRepository(databaseHelper);
            LoadClientes();
        }


        private void LoadClientes()
        {
            List<Cliente> clientes = clienteRepository.GetClientes();
            dgvClientes.DataSource = clientes;
            PersonalizarDataGridView();
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
            dgvClientes.Columns["BdEst"].Visible = false; // Asegúrate de que no se muestre esta columna

            dgvClientes.Columns["NombreCompleto"].HeaderText = "Cliente";

            // Mover la columna NombreCompleto al principio
            dgvClientes.Columns["NombreCompleto"].DisplayIndex = 0;

            // Puedes personalizar el ancho de las columnas si lo deseas
            dgvClientes.Columns["NombreCompleto"].Width = 200;
            dgvClientes.Columns["NuCedula"].HeaderText = "Cédula";
            dgvClientes.Columns["NuCedula"].Width = 150;
            dgvClientes.Columns["NuCelular"].HeaderText = "Celular";
            dgvClientes.Columns["NuCelular"].Width = 150;
            dgvClientes.Columns["Correo"].HeaderText = "Correo Electrónico";
            dgvClientes.Columns["Correo"].Width = 250;

            // Ajustar el ancho de todas las columnas automáticamente
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Eliminar la columna de selección de filas
            dgvClientes.RowHeadersVisible = false;
        }

        private void txtBuscarNombre_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }
    }
}


