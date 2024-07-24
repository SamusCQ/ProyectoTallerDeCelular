using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class EditarClienteControl : UserControl
    {
        private DatabaseHelper databaseHelper;
        private Panel panelVentana;
        private int idCliente;
        private ClienteRepository clienteRepository;

        public EditarClienteControl(DatabaseHelper databaseHelper, Panel panelVentana, int idCliente)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            this.idCliente = idCliente;
            this.clienteRepository = new ClienteRepository(databaseHelper);

            // Cargar los datos del cliente en los campos
            CargarDatosCliente();
        }

        private void CargarDatosCliente()
        {
            Cliente cliente = clienteRepository.ObtenerClientePorId(idCliente);
            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtCedula.Text = cliente.NuCedula;
                txtCelular.Text = cliente.NuCelular;
                txtCorreo.Text = cliente.Correo;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    Cliente cliente = new Cliente
                    {
                        IdCliente = idCliente,
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        NuCedula = txtCedula.Text,
                        NuCelular = txtCelular.Text,
                        Correo = txtCorreo.Text,
                        BdEst = 1 // Suponiendo que 1 significa activo
                    };

                    clienteRepository.ActualizarCliente(cliente);
                    MessageBox.Show("Cliente actualizado exitosamente");

                    // Regresar a ClienteControl
                    ClienteControl clienteControl = new ClienteControl(databaseHelper, panelVentana);
                    panelVentana.Controls.Clear();
                    panelVentana.Controls.Add(clienteControl);
                    clienteControl.Dock = DockStyle.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el cliente: " + ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Regresar a ClienteControl sin guardar cambios
            ClienteControl clienteControl = new ClienteControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(clienteControl);
            clienteControl.Dock = DockStyle.Fill;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtCelular.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos.");
                return false;
            }

            if (txtCedula.Text.Length != 10)
            {
                MessageBox.Show("La cédula debe tener 10 caracteres.");
                return false;
            }

            if (txtCelular.Text.Length != 10)
            {
                MessageBox.Show("El número de celular debe tener 10 caracteres.");
                return false;
            }

            if (!EsCorreoValido(txtCorreo.Text))
            {
                MessageBox.Show("El correo electrónico no es válido.");
                return false;
            }

            return true;
        }

        private bool EsCorreoValido(string correo)
        {
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patronCorreo);
        }
    }
}
