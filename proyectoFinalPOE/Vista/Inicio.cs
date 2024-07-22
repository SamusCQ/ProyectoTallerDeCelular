using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class Inicio : Form
    {
        private int userRole;
        public Inicio(int role)
        {
            InitializeComponent();
            userRole = role;
            ConfigureUIBasedOnRole();
        }

        private void ConfigureUIBasedOnRole()
        {
            switch (userRole)
            {
                case 1: // Técnico
                        // Configurar la UI para el rol Técnico
                    this.Text = "Inicio - Técnico";
                    // Mostrar u ocultar controles específicos para Técnico
                    break;
                case 2: // Cliente
                        // Configurar la UI para el rol Cliente
                    this.Text = "Inicio - Cliente";
                    // Mostrar u ocultar controles específicos para Cliente
                    break;
                case 3: // Administrador
                        // Configurar la UI para el rol Administrador
                    this.Text = "Inicio - Administrador";
                    // Mostrar u ocultar controles específicos para Administrador
                    break;
                default:
                    MessageBox.Show("Rol desconocido.");
                    break;
            }
        }

    }
}
