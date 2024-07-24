using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            cmbRoles.DataSource = roles.Distinct().ToList();
            cmbRoles.DisplayMember = "Descripcion";
            cmbRoles.ValueMember = "IdRol";

            // Configurar el evento de FormClosing
            this.FormClosing += new FormClosingEventHandler(SeleccionRol_FormClosing);
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

        private void SeleccionRol_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelClear_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.Cursor = Cursors.Hand;
            }
        }

        private void labelClear_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.Cursor = Cursors.Default;
            }
        }

        private void labelExit_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.Cursor = Cursors.Hand;
            }
        }

        private void labelExit_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.Cursor = Cursors.Default;
            }
        }
    }


}

