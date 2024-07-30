using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista.Repuesto
{
    public partial class EditarRepuestoControl : UserControl
    {
        private int idRepuesto;
        private DatabaseConector databaseHelper;
        private RepuestoRepository repuestoRepository;
        private MarcaRepository marcaRepository;
        private ModeloCelularRepository modeloCelularRepository;
        private TipoRepuestoRepository tipoRepuestoRepository;
        private Panel panelVentana;

        public EditarRepuestoControl(int idRepuesto, DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.idRepuesto = idRepuesto;
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            repuestoRepository = new RepuestoRepository(databaseHelper);
            marcaRepository = new MarcaRepository(databaseHelper);
            modeloCelularRepository = new ModeloCelularRepository(databaseHelper);
            tipoRepuestoRepository = new TipoRepuestoRepository(databaseHelper);
            LoadComboboxes();
            LoadRepuestoData();
        }

        private void LoadComboboxes()
        {
            cmbMarca.DataSource = marcaRepository.GetMarcas();
            cmbMarca.DisplayMember = "Descripcion";
            cmbMarca.ValueMember = "IdMarca";

            cmbTipo.DataSource = tipoRepuestoRepository.GetTipos();
            cmbTipo.DisplayMember = "Descripcion";
            cmbTipo.ValueMember = "IdTipo";

            cmbMarca.SelectedIndexChanged += new EventHandler(cmbMarca_SelectedIndexChanged);
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedValue != null && cmbMarca.SelectedValue is int idMarca)
            {
                cmbModelo.DataSource = modeloCelularRepository.GetModelosPorMarca(idMarca);
                cmbModelo.DisplayMember = "Descripcion";
                cmbModelo.ValueMember = "IdModelo";
            }
        }

        private void LoadRepuestoData()
        {
            proyectoFinalPOE.Modelo.Repuesto repuesto = repuestoRepository.ObtenerRepuestoPorId(idRepuesto);
            if (repuesto != null)
            {
                txtDescripcion.Text = repuesto.Descripcion;
                cmbMarca.SelectedValue = repuesto.IdMarca;
                cmbModelo.SelectedValue = repuesto.IdModelo;
                cmbTipo.SelectedValue = repuesto.IdTipo;
                txtValor.Text = repuesto.Valor.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            proyectoFinalPOE.Modelo.Repuesto repuesto = new proyectoFinalPOE.Modelo.Repuesto
            {
                IdRepuesto = idRepuesto,
                Descripcion = txtDescripcion.Text,
                IdMarca = (int)cmbMarca.SelectedValue,
                IdModelo = (int)cmbModelo.SelectedValue,
                IdTipo = (int)cmbTipo.SelectedValue,
                Valor = decimal.Parse(txtValor.Text)
            };

            repuestoRepository.ActualizarRepuesto(repuesto);
            MessageBox.Show("Repuesto actualizado correctamente.");
            VolverALista();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            VolverALista();
        }

        private void VolverALista()
        {
            RepuestoControl repuestoControl = new RepuestoControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(repuestoControl);
            repuestoControl.Dock = DockStyle.Fill;
        }
    }
}


