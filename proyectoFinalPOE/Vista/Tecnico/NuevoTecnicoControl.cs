using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class NuevoTecnicoControl : UserControl
    {
        private DatabaseConector databaseHelper;
        private Panel panelVentana;
        private TecnicoRepository tecnicoRepository;

        public NuevoTecnicoControl(DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            this.tecnicoRepository = new TecnicoRepository(databaseHelper);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    Tecnico tecnico = new Tecnico
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        NuCedula = txtCedula.Text,
                        NuCelular = txtCelular.Text,
                        Correo = txtCorreo.Text,
                        BdEst = 1 // Suponiendo que 1 significa activo
                    };

                    tecnicoRepository.GuardarTecnico(tecnico);
                    MessageBox.Show("Técnico guardado exitosamente");

                    // Regresar a TecnicoControl
                    TecnicoControl tecnicoControl = new TecnicoControl(databaseHelper, panelVentana);
                    panelVentana.Controls.Clear();
                    panelVentana.Controls.Add(tecnicoControl);
                    tecnicoControl.Dock = DockStyle.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el técnico: " + ex.Message);
                }
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            // Regresar a TecnicoControl
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
