using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
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

            // Calcular el total de botones y el espacio requerido
            int totalBotones = opciones.Count;
            int buttonHeight = 30;
            int spacing = 10;
            int totalHeight = (buttonHeight + spacing) * totalBotones - spacing;

            // Calcular la posición inicial para centrar los botones
            int startY = (panelOpciones.Height - totalHeight) / 2;

            for (int i = 0; i < opciones.Count; i++)
            {
                Opcion opcion = opciones[i];

                Button btn = new Button();
                btn.Text = opcion.Descripcion;
                btn.Tag = opcion.ViewPath;
                btn.Click += new EventHandler(OpcionButton_Click);

                // Ajustar la posición del botón
                btn.Size = new Size(panelOpciones.Width - 20, buttonHeight);
                btn.Location = new Point(10, startY + (buttonHeight + spacing) * i);

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
                // Agrega la lógica para construir la ruta completa basándose en la estructura de carpetas y espacios de nombres
                string baseNamespace = "proyectoFinalPOE.Vista";
                string fullPath = string.Empty;

                if (viewPath.Contains("Repuesto"))
                {
                    fullPath = baseNamespace + ".Repuesto." + viewPath;
                }
                else if (viewPath.Contains("Reparacion"))
                {
                    fullPath = baseNamespace + ".Reparaciones." + viewPath;
                }
                else
                {
                    fullPath = baseNamespace + "." + viewPath;
                }

                MessageBox.Show("Intentando cargar: " + fullPath);

                // Busca el tipo a través de todas las clases cargadas en el dominio de la aplicación
                Type type = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .FirstOrDefault(t => t.FullName == fullPath);

                if (type != null)
                {
                    MessageBox.Show("Tipo encontrado: " + fullPath);
                    return (UserControl)Activator.CreateInstance(type, new object[] { databaseHelper, panelVentana });
                }
                else
                {
                    MessageBox.Show("No se encontró la vista: " + fullPath);
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
