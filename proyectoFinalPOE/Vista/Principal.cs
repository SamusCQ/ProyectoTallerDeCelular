using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Negocio;
using proyectoFinalPOE.Vista;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proyectoFinalPOE
{
    public partial class Principal : Form
    {
        private UsuarioService usuarioService;
        private DatabaseHelper databaseHelper;

        public Principal()
        {
            InitializeComponent();
            databaseHelper = new DatabaseHelper();
            usuarioService = new UsuarioService(databaseHelper);

            var usuarios = usuarioService.ObtenerUsuarios();
            this.FormClosing += new FormClosingEventHandler(Principal_FormClosing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtContrasena.Text;

            if (usuarioService.VerificarCredenciales(username, password))
            {
                MessageBox.Show("Inicio de sesión exitoso.");

                List<UserRole> userRoles = usuarioService.GetUserRoles(username, password);

                if (userRoles.Count > 1)
                {
                    // Abrir la ventana de selección de roles
                    SeleccionRol seleccionRolVentana = new SeleccionRol(userRoles, username, password);
                    seleccionRolVentana.Show();
                    this.Hide(); // Ocultar la ventana de inicio de sesión
                }
                else if (userRoles.Count == 1)
                {
                    // Abrir la ventana de inicio directamente si solo tiene un rol
                    Inicio nuevaVentana = new Inicio(userRoles[0].IdRol);
                    nuevaVentana.Show();
                    this.Hide(); // Ocultar la ventana de inicio de sesión
                }
                else
                {
                    MessageBox.Show("No se encontraron roles para el usuario.");
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}