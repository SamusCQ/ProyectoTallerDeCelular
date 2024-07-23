using proyectoFinalPOE.Controlador;
using System;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class NuevoClienteControl : UserControl
    {
        private DatabaseHelper databaseHelper;
        private Panel panelVentana;

        public NuevoClienteControl(DatabaseHelper databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Implementa la lógica para guardar el cliente
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            // Regresar a ClienteControl
            ClienteControl clienteControl = new ClienteControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(clienteControl);
            clienteControl.Dock = DockStyle.Fill;
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            // Implementa la lógica que necesites cuando el texto de txtCedula cambie
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Implementa la lógica que necesites cuando el label3 sea clickeado
        }
    }
}

