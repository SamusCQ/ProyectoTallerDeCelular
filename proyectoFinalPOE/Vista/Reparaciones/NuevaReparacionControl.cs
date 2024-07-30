using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using proyectoFinalPOE.Vista.Reparaciones;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ModeloRepuesto = proyectoFinalPOE.Modelo.Repuesto;

namespace proyectoFinalPOE.Vista
{
    public partial class NuevaReparacionControl : UserControl
    {
        private DatabaseConector databaseHelper;
        private ReparacionRepository reparacionRepository;
        private RepuestoRepository repuestoRepository;
        private ClienteRepository clienteRepository;
        private CelularRepository celularRepository;
        private EstadoRepository estadoRepository;
        private Panel panelVentana;

        public NuevaReparacionControl(DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            reparacionRepository = new ReparacionRepository(databaseHelper);
            repuestoRepository = new RepuestoRepository(databaseHelper);
            clienteRepository = new ClienteRepository(databaseHelper);
            celularRepository = new CelularRepository(databaseHelper);
            estadoRepository = new EstadoRepository(databaseHelper);
            LoadComboboxes();
        }

        private void LoadComboboxes()
        {
            cmbClientes.DataSource = clienteRepository.GetClientes();
            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "IdCliente";

            cmbClientes.SelectedIndexChanged += new EventHandler(cmbClientes_SelectedIndexChanged);

            cmbEstado.DataSource = estadoRepository.GetEstados();
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "IdEstado";
            cmbEstado.SelectedValue = 1; // Estado 
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null && cmbClientes.SelectedValue is int idCliente)
            {
                cmbCelulares.DataSource = celularRepository.GetCelularesPorCliente(idCliente);
                cmbCelulares.DisplayMember = "NombreModelo";
                cmbCelulares.ValueMember = "IdCelular";
            }
        }





        private void cmbCelulares_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCelulares.SelectedValue != null && cmbCelulares.SelectedValue is int idCelular)
            {
                // Obtener el modelo y la marca del celular seleccionado
                var celular = celularRepository.GetCelularPorId(idCelular);
                if (celular != null)
                {
                    // Obtener los repuestos por marca y modelo
                    var repuestos = repuestoRepository.GetRepuestosPorMarcaYModelo(celular.IdMarca, celular.IdModelo);
                    clbRepuestos.DataSource = repuestos;
                    clbRepuestos.DisplayMember = "Descripcion";
                    clbRepuestos.ValueMember = "IdRepuesto";
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Reparacion nuevaReparacion = new Reparacion
            {
                IdCliente = (int)cmbClientes.SelectedValue,
                IdCelular = (int)cmbCelulares.SelectedValue,
                IdEstado = 1, // Estado pendiente
                Descripcion = txtDescripcion.Text,
                BdEst = 1
            };

            int idReparacion = reparacionRepository.AgregarReparacion(nuevaReparacion);

            // Añadir repuestos seleccionados a la reparación y actualizar la cantidad
            foreach (var item in clbRepuestos.CheckedItems)
            {
                if (item is ModeloRepuesto repuesto)
                {
                    reparacionRepository.AgregarReparacionRepuesto(idReparacion, repuesto.IdRepuesto);
                    repuestoRepository.ActualizarCantidadRepuesto(repuesto.IdRepuesto, 1); // Resta 1 del repuesto
                }
            }

            MessageBox.Show("Reparación creada exitosamente.");
            VolverALista();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            VolverALista();
        }

        private void VolverALista()
        {
            ReparacionesControl reparacionControl = new ReparacionesControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(reparacionControl);
            reparacionControl.Dock = DockStyle.Fill;
        }


    }
}


