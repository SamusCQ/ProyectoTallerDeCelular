using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class EditarTecnicoControl : UserControl
    {
        private DatabaseConector databaseHelper;
        private Panel panelVentana;
        private int idTecnico;
        private TecnicoRepository tecnicoRepository;

        public EditarTecnicoControl(DatabaseConector databaseHelper, Panel panelVentana, int idTecnico)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            this.idTecnico = idTecnico;
            this.tecnicoRepository = new TecnicoRepository(databaseHelper);

            // Cargar los datos del técnico en los campos
            CargarDatosTecnico();
        }

        private void CargarDatosTecnico()
        {
            Tecnico tecnico = tecnicoRepository.ObtenerTecnicoPorId(idTecnico);
            if (tecnico != null)
            {
                txtNombre.Text = tecnico.Nombre;
                txtApellido.Text = tecnico.Apellido;
                txtCedula.Text = tecnico.NuCedula;
                txtCelular.Text = tecnico.NuCelular;
                txtCorreo.Text = tecnico.Correo;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    Tecnico tecnico = new Tecnico
                    {
                        IdTecnico = idTecnico,
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        NuCedula = txtCedula.Text,
                        NuCelular = txtCelular.Text,
                        Correo = txtCorreo.Text,
                        BdEst = 1 // Suponiendo que 1 significa activo
                    };

                    tecnicoRepository.ActualizarTecnico(tecnico);
                    MessageBox.Show("Técnico actualizado exitosamente");

                    // Regresar a TecnicoControl
                    TecnicoControl tecnicoControl = new TecnicoControl(databaseHelper, panelVentana);
                    panelVentana.Controls.Clear();
                    panelVentana.Controls.Add(tecnicoControl);
                    tecnicoControl.Dock = DockStyle.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el técnico: " + ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Regresar a TecnicoControl sin guardar cambios
            TecnicoControl tecnicoControl = new TecnicoControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(tecnicoControl);
            tecnicoControl.Dock = DockStyle.Fill;
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

