using proyectoFinalPOE.Controlador;
using System;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class NuevoCelularControl : UserControl
    {
        private DatabaseHelper databaseHelper;
        private Panel panelVentana;

        public NuevoCelularControl(DatabaseHelper databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Implementar la lógica para guardar el nuevo celular
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Volver a la vista de CelularesControl
            CelularesControl celularesControl = new CelularesControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(celularesControl);
            celularesControl.Dock = DockStyle.Fill;
        }
    }
}
