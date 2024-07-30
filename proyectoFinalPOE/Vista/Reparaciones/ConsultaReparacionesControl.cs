using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Repositorio;
using System;
using System.Data;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista.Reparaciones
{
    public partial class ConsultaReparacionesControl : UserControl
    {
        private DatabaseConector databaseHelper;
        private ReparacionRepository reparacionRepository;
        private Panel panelVentana;
        private int idCliente;

        public ConsultaReparacionesControl()
        {
            InitializeComponent();
        }

        public ConsultaReparacionesControl(DatabaseConector databaseHelper, Panel panelVentana, int idCliente)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            this.idCliente = idCliente;
            reparacionRepository = new ReparacionRepository(databaseHelper);

            MessageBox.Show("Constructor llamado con idCliente: " + idCliente);
            LoadReparaciones();
        }

        private void LoadReparaciones()
        {
            DataTable dtReparaciones = reparacionRepository.GetReparacionesPorClienteDataTable(idCliente);
            MessageBox.Show("Reparaciones cargadas: " + dtReparaciones.Rows.Count);
            dgvReparaciones.DataSource = dtReparaciones;
            PersonalizarDataGridView();
        }

        private void PersonalizarDataGridView()
        {
            dgvReparaciones.AllowUserToAddRows = false;

            if (dgvReparaciones.Columns.Contains("idReparacion"))
                dgvReparaciones.Columns["idReparacion"].Visible = false;

            if (dgvReparaciones.Columns.Contains("idCliente"))
                dgvReparaciones.Columns["idCliente"].Visible = false;

            if (dgvReparaciones.Columns.Contains("idCelular"))
                dgvReparaciones.Columns["idCelular"].Visible = false;

            if (dgvReparaciones.Columns.Contains("idEstado"))
                dgvReparaciones.Columns["idEstado"].Visible = false;

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

            if (dgvReparaciones.Columns.Contains("Modelo"))
            {
                dgvReparaciones.Columns["Modelo"].HeaderText = "Modelo";
                dgvReparaciones.Columns["Modelo"].DisplayIndex = 5;
            }

            dgvReparaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvReparaciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvReparaciones.AllowUserToResizeColumns = true;
            dgvReparaciones.AllowUserToResizeRows = true;
            dgvReparaciones.RowHeadersVisible = false;
            dgvReparaciones.ScrollBars = ScrollBars.Both;
        }
    }
}
