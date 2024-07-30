using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista.Reparaciones
{
    public partial class CambiarEstadoReparacionesControl : UserControl
    {
        private DatabaseConector databaseHelper;
        private ReparacionRepository reparacionRepository;
        private int idReparacion;
        private Panel panelVentana;

        public CambiarEstadoReparacionesControl(DatabaseConector databaseHelper, int idReparacion, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.idReparacion = idReparacion;
            this.panelVentana = panelVentana;
            reparacionRepository = new ReparacionRepository(databaseHelper);
            LoadEstados();
        }

        private void LoadEstados()
        {
            // Obtener los estados disponibles y cargarlos en el ComboBox
            DataTable dtEstados = reparacionRepository.GetEstados();
            cmbEstado.DataSource = dtEstados;
            cmbEstado.DisplayMember = "descripcion";
            cmbEstado.ValueMember = "idEstado";
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            int idEstado = Convert.ToInt32(cmbEstado.SelectedValue);
            reparacionRepository.ActualizarEstadoReparacion(idReparacion, idEstado);
            MessageBox.Show("Estado actualizado correctamente.");
            // Volver a la lista de reparaciones
            ReparacionesControl reparacionesControl = new ReparacionesControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(reparacionesControl);
            reparacionesControl.Dock = DockStyle.Fill;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            ReparacionesControl reparacionesControl = new ReparacionesControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(reparacionesControl);
            reparacionesControl.Dock = DockStyle.Fill;
        }
    }
}

