using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista.Repuesto
{
    public partial class NuevoRepuestoControl : UserControl
    {
        private DatabaseConector databaseHelper;
        private RepuestoRepository repuestoRepository;
        private MarcaRepository marcaRepository;
        private ModeloCelularRepository modeloCelularRepository;
        private TipoRepuestoRepository tipoRepuestoRepository;
        private Panel panelVentana;

        public NuevoRepuestoControl(DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            repuestoRepository = new RepuestoRepository(databaseHelper);
            marcaRepository = new MarcaRepository(databaseHelper);
            modeloCelularRepository = new ModeloCelularRepository(databaseHelper);
            tipoRepuestoRepository = new TipoRepuestoRepository(databaseHelper);
            LoadComboboxes();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            proyectoFinalPOE.Modelo.Repuesto repuesto = new proyectoFinalPOE.Modelo.Repuesto
            {
                Descripcion = txtDescripcion.Text,
                IdMarca = (int)cmbMarca.SelectedValue,
                IdModelo = (int)cmbModelo.SelectedValue,
                IdTipo = (int)cmbTipo.SelectedValue,
                Valor = decimal.Parse(txtValor.Text),
                Cantidad = 1, // Asigna un valor predeterminado para la cantidad
                FechaIngreso = DateTime.Now, // Asigna la fecha de ingreso actual
                BdEst = 1 // O el valor que corresponda
            };

            repuestoRepository.AgregarRepuesto(repuesto);
            MessageBox.Show("Repuesto agregado correctamente.");
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
