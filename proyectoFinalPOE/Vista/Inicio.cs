using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class Inicio : Form
    {
        private int userRole;
        private DatabaseHelper databaseHelper;
        private OpcionRepository opcionRepository;

        public Inicio(int role)
        {
            InitializeComponent();
            this.userRole = role;
            this.databaseHelper = new DatabaseHelper();
            this.opcionRepository = new OpcionRepository(databaseHelper);
            this.FormClosing += new FormClosingEventHandler(Inicio_FormClosing);
            LoadOpciones();
        }

        private void LoadOpciones()
        {
            List<Opcion> opciones = opcionRepository.GetOpcionesByRol(userRole);

            foreach (Opcion opcion in opciones)
            {
                Button btn = new Button();
                btn.Text = opcion.Descripcion;
                btn.Tag = opcion.ViewPath;
                btn.Click += new EventHandler(OpcionButton_Click);
                panelOpciones.Controls.Add(btn);
            }
        }

        private void OpcionButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string viewPath = btn.Tag as string;

            // Aquí debes cargar la vista correspondiente en el panelVentana
            UserControl uc = CreateViewInstance(viewPath);
            if (uc != null)
            {
                panelVentana.Controls.Clear();
                panelVentana.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("No se pudo cargar la vista: " + viewPath);
            }
        }

        private UserControl CreateViewInstance(string viewPath)
        {
            try
            {
                // Asume que los UserControls están en el namespace `proyectoFinalPOE.Vista`
                Type type = Type.GetType("proyectoFinalPOE.Vista." + viewPath);
                if (type != null)
                {
                    // Crear una instancia del UserControl pasando el DatabaseHelper como parámetro
                    return (UserControl)Activator.CreateInstance(type, databaseHelper);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la instancia de la vista: " + ex.Message);
                return null;
            }
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

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
