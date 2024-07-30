using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Repositorio;
using System;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista.Repuesto
{
    public partial class InsertarCantidadControl : UserControl
    {
        private int idRepuesto;
        private DatabaseConector databaseHelper;
        private Panel panelVentana;
        private RepuestoRepository repuestoRepository;

        public InsertarCantidadControl(int idRepuesto, DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.idRepuesto = idRepuesto;
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            repuestoRepository = new RepuestoRepository(databaseHelper);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int cantidad))
            {
                repuestoRepository.InsertarCantidad(idRepuesto, cantidad);
                MessageBox.Show("Cantidad insertada correctamente");
                panelVentana.Controls.Clear();
                panelVentana.Controls.Add(new RepuestoControl(databaseHelper, panelVentana));
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número válido");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(new RepuestoControl(databaseHelper, panelVentana));
        }
    }
}
