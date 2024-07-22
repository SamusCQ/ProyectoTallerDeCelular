using proyectoFinalPOE.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static proyectoFinalPOE.Controlador.DatabaseHelper;

namespace proyectoFinalPOE.Vista
{
    public partial class SeleccionRol : Form
    {
        private List<UserRole> roles;
        private string username;
        private string password;

        public SeleccionRol(List<UserRole> roles, string username, string password)
        {
            InitializeComponent();
            this.roles = roles;
            this.username = username;
            this.password = password;

            // Configurar el ComboBox para mostrar la descripción pero almacenar el idRol
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "Descripcion";
            cmbRoles.ValueMember = "IdRol";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedItem != null)
            {
                int selectedRole = (int)cmbRoles.SelectedValue;

                // Abrir la nueva ventana y pasar el rol del usuario
                Inicio nuevaVentana = new Inicio(selectedRole);
                nuevaVentana.Show();
                this.Hide(); // Ocultar la ventana de selección de rol
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un rol.");
            }
        }
    }

}
