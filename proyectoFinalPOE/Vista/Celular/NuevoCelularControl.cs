using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class NuevoCelularControl : UserControl
    {
        private CelularRepository celularRepository;
        private ClienteRepository clienteRepository;
        private ModeloCelularRepository modeloCelularRepository;
        private ColorRepository colorRepository;
        private DatabaseConector databaseHelper;
        private Panel panelVentana;

        public NuevoCelularControl(DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            celularRepository = new CelularRepository(databaseHelper);
            clienteRepository = new ClienteRepository(databaseHelper);
            modeloCelularRepository = new ModeloCelularRepository(databaseHelper);
            colorRepository = new ColorRepository(databaseHelper);
            LoadComboboxes();
        }

        private void LoadComboboxes()
        {
            cmbClientes.DataSource = clienteRepository.GetClientes();
            cmbClientes.DisplayMember = "NombreCompleto"; // Asegúrate de tener una propiedad que concatene el nombre y apellido
            cmbClientes.ValueMember = "IdCliente";

            cmbMarcas.DataSource = modeloCelularRepository.GetMarcas();
            cmbMarcas.DisplayMember = "Descripcion";
            cmbMarcas.ValueMember = "IdMarca";

            cmbColores.DataSource = colorRepository.GetColores();
            cmbColores.DisplayMember = "Descripcion";
            cmbColores.ValueMember = "IdColor";
        }

        private void cmbMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarcas.SelectedValue != null && cmbMarcas.SelectedValue is int)
            {
                int idMarca = (int)cmbMarcas.SelectedValue;
                LoadModelos(idMarca);
            }
        }

        private void LoadModelos(int idMarca)
        {
            cmbModelos.DataSource = modeloCelularRepository.GetModelosPorMarca(idMarca);
            cmbModelos.DisplayMember = "Descripcion";
            cmbModelos.ValueMember = "IdModelo";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Celular nuevoCelular = new Celular
            {
                IdCliente = (int)cmbClientes.SelectedValue,
                IdModelo = (int)cmbModelos.SelectedValue,
                IdColor = (int)cmbColores.SelectedValue,
                BdEst = 1 // Asumiendo que 1 significa activo
            };

            celularRepository.AgregarCelular(nuevoCelular);
            MessageBox.Show("Celular guardado con éxito.");
            panelVentana.Controls.Clear();
            CelularesControl celularesControl = new CelularesControl(databaseHelper, panelVentana);
            panelVentana.Controls.Add(celularesControl);
            celularesControl.Dock = DockStyle.Fill;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelVentana.Controls.Clear();
            CelularesControl celularesControl = new CelularesControl(databaseHelper, panelVentana);
            panelVentana.Controls.Add(celularesControl);
            celularesControl.Dock = DockStyle.Fill;
        }
    }
}
