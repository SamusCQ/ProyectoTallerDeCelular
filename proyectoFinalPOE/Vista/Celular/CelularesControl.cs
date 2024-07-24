using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class CelularesControl : UserControl
    {
        private CelularRepository celularRepository;
        private DatabaseHelper databaseHelper;
        private Panel panelVentana;

        public CelularesControl(DatabaseHelper databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            celularRepository = new CelularRepository(databaseHelper);
            LoadCelulares();
        }

        private void LoadCelulares()
        {
            List<Celular> celulares = celularRepository.GetCelulares();
            dgvCelulares.DataSource = celulares;
            PersonalizarDataGridView();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtBuscarCelular.Text;
            List<Celular> celulares = celularRepository.BuscarCelularesPorNombreCliente(nombreCliente);
            dgvCelulares.DataSource = celulares;
            PersonalizarDataGridView();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            NuevoCelularControl nuevoCelularControl = new NuevoCelularControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(nuevoCelularControl);
            nuevoCelularControl.Dock = DockStyle.Fill;
        }

        private void PersonalizarDataGridView()
        {
            dgvCelulares.Columns["IdCelular"].Visible = false;
            dgvCelulares.Columns["BdEst"].Visible = false;

            dgvCelulares.Columns["NombreCliente"].HeaderText = "Cliente";
            dgvCelulares.Columns["NombreModelo"].HeaderText = "Modelo";
            dgvCelulares.Columns["Color"].HeaderText = "Color";

            dgvCelulares.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCelulares.RowHeadersVisible = false;
        }

        private void txtBuscarCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }
    }
}


