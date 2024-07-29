using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista.Reparaciones
{
    public partial class ReparacionesControl : UserControl
    {
        private DatabaseHelper databaseHelper;
        private ReparacionRepository reparacionRepository;
        private Panel panelVentana;


        public ReparacionesControl(DatabaseHelper databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            reparacionRepository = new ReparacionRepository(databaseHelper);
            LoadReparaciones();

        }

        private void LoadReparaciones()
        {
            DataTable dtReparaciones = reparacionRepository.GetReparacionesConRepuestos();
            dgvReparaciones.DataSource = dtReparaciones;

            // Imprimir los nombres de las columnas para verificar
            foreach (DataColumn column in dtReparaciones.Columns)
            {
                Console.WriteLine(column.ColumnName);
            }

            PersonalizarDataGridView();
        }


        private void PersonalizarDataGridView()
        {
            // Ocultar las columnas de ID solo si existen
            if (dgvReparaciones.Columns.Contains("idReparacion"))
                dgvReparaciones.Columns["idReparacion"].Visible = false;

            if (dgvReparaciones.Columns.Contains("idCliente"))
                dgvReparaciones.Columns["idCliente"].Visible = false;

            if (dgvReparaciones.Columns.Contains("idCelular"))
                dgvReparaciones.Columns["idCelular"].Visible = false;

            if (dgvReparaciones.Columns.Contains("idEstado"))
                dgvReparaciones.Columns["idEstado"].Visible = false;

            // Configurar los encabezados y el orden de las columnas visibles solo si existen
            if (dgvReparaciones.Columns.Contains("Reparacion"))
            {
                dgvReparaciones.Columns["Reparacion"].HeaderText = "Descripción de la Reparación";
                dgvReparaciones.Columns["Reparacion"].DisplayIndex = 0;
            }

            if (dgvReparaciones.Columns.Contains("Cliente"))
            {
                dgvReparaciones.Columns["Cliente"].HeaderText = "Cliente";
                dgvReparaciones.Columns["Cliente"].DisplayIndex = 1;
            }

            if (dgvReparaciones.Columns.Contains("Celular"))
            {
                dgvReparaciones.Columns["Celular"].HeaderText = "Celular";
                dgvReparaciones.Columns["Celular"].DisplayIndex = 2;
            }

            if (dgvReparaciones.Columns.Contains("Estado"))
            {
                dgvReparaciones.Columns["Estado"].HeaderText = "Estado";
                dgvReparaciones.Columns["Estado"].DisplayIndex = 3;
            }

            if (dgvReparaciones.Columns.Contains("Repuestos"))
            {
                dgvReparaciones.Columns["Repuestos"].HeaderText = "Repuestos";
                dgvReparaciones.Columns["Repuestos"].DisplayIndex = 4;
            }

            // Ajustar el modo de ajuste de las columnas
            dgvReparaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReparaciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvReparaciones.AllowUserToResizeColumns = true;
            dgvReparaciones.AllowUserToResizeRows = true;
            dgvReparaciones.RowHeadersVisible = false;
        }






        private void btnNuevaReparacion_Click(object sender, EventArgs e)
        {
            NuevaReparacionControl nuevaReparacionControl = new NuevaReparacionControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(nuevaReparacionControl);
            nuevaReparacionControl.Dock = DockStyle.Fill;
        }
    }
}
