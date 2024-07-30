using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class EditarCelularControl : UserControl
    {
        private int idCelular;
        private DatabaseConector databaseHelper;
        private CelularRepository celularRepository;
        private MarcaRepository marcaRepository;
        private ModeloCelularRepository modeloCelularRepository;
        private ColorRepository colorRepository;
        private Panel panelVentana;

        public EditarCelularControl(int idCelular, DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.idCelular = idCelular;
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            celularRepository = new CelularRepository(databaseHelper);
            marcaRepository = new MarcaRepository(databaseHelper);
            modeloCelularRepository = new ModeloCelularRepository(databaseHelper);
            colorRepository = new ColorRepository(databaseHelper);
            LoadComboboxes();
            LoadCelularData();
        }

        private void LoadComboboxes()
        {
            cmbMarcaCelular.DataSource = marcaRepository.GetMarcas();
            cmbMarcaCelular.DisplayMember = "Descripcion";
            cmbMarcaCelular.ValueMember = "IdMarca";  // Asegúrate de que esto esté configurado correctamente

            cmbColorCelular.DataSource = colorRepository.GetColores();
            cmbColorCelular.DisplayMember = "Descripcion";
            cmbColorCelular.ValueMember = "IdColor";

            cmbMarcaCelular.SelectedIndexChanged += new EventHandler(cmbMarcaCelular_SelectedIndexChanged);
        }


        private void cmbMarcaCelular_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarcaCelular.SelectedValue != null && cmbMarcaCelular.SelectedValue is int idMarca)
            {
                cmbModeloCelular.DataSource = modeloCelularRepository.GetModelosPorMarca(idMarca);
                cmbModeloCelular.DisplayMember = "Descripcion";
                cmbModeloCelular.ValueMember = "IdModelo";
            }
        }




        private void LoadCelularData()
        {
            Celular celular = celularRepository.ObtenerCelularPorId(idCelular);
            if (celular != null)
            {
                txtNombreCliente.Text = celular.NombreCliente;

                // Cargar marcas
                cmbMarcaCelular.DataSource = marcaRepository.GetMarcas();
                cmbMarcaCelular.DisplayMember = "Descripcion";
                cmbMarcaCelular.ValueMember = "IdMarca";
                cmbMarcaCelular.SelectedValue = celular.IdMarca;

                // Cargar modelos según la marca seleccionada
                cmbModeloCelular.DataSource = modeloCelularRepository.GetModelosPorMarca(celular.IdMarca);
                cmbModeloCelular.DisplayMember = "Descripcion";
                cmbModeloCelular.ValueMember = "IdModelo";
                cmbModeloCelular.SelectedValue = celular.IdModelo;

                // Cargar colores
                cmbColorCelular.DataSource = colorRepository.GetColores();
                cmbColorCelular.DisplayMember = "Descripcion";
                cmbColorCelular.ValueMember = "IdColor";
                cmbColorCelular.SelectedValue = celular.IdColor;
            }
        }





        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Celular celular = new Celular
            {
                IdCelular = idCelular,
                IdModelo = (int)cmbModeloCelular.SelectedValue,
                IdColor = (int)cmbColorCelular.SelectedValue,
                // No necesitas el IdMarca aquí ya que se usa para obtener modelos
            };

            celularRepository.ActualizarCelular(celular);
            MessageBox.Show("Celular actualizado correctamente.");
            VolverALista();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            VolverALista();
        }

        private void VolverALista()
        {
            CelularesControl celularesControl = new CelularesControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(celularesControl);
            celularesControl.Dock = DockStyle.Fill;
        }
    }
}


