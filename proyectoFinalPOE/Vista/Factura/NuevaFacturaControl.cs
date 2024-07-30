using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using ModeloRepuesto = proyectoFinalPOE.Modelo.Repuesto;

namespace proyectoFinalPOE.Vista
{
    public partial class NuevaFacturaControl : UserControl
    {
        private DatabaseConector databaseHelper;
        private FacturaRepository facturaRepository;
        private ClienteRepository clienteRepository;
        private ReparacionRepository reparacionRepository;
        private Panel panelVentana;

        public NuevaFacturaControl(DatabaseConector databaseHelper, Panel panelVentana)
        {
            InitializeComponent();
            this.databaseHelper = databaseHelper;
            this.panelVentana = panelVentana;
            facturaRepository = new FacturaRepository(databaseHelper);
            clienteRepository = new ClienteRepository(databaseHelper);
            reparacionRepository = new ReparacionRepository(databaseHelper);
            LoadComboboxes();
        }

        private void LoadComboboxes()
        {
            cmbClientes.DataSource = clienteRepository.GetClientes();
            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "IdCliente";
            cmbClientes.SelectedIndexChanged += new EventHandler(cmbClientes_SelectedIndexChanged);
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null && cmbClientes.SelectedValue is int idCliente)
            {
                cmbReparaciones.DataSource = reparacionRepository.GetReparacionesPorCliente(idCliente);
                cmbReparaciones.DisplayMember = "Descripcion";
                cmbReparaciones.ValueMember = "IdReparacion";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbReparaciones.SelectedValue != null && cmbClientes.SelectedValue != null)
            {
                int idReparacion = (int)cmbReparaciones.SelectedValue;
                int idCliente = (int)cmbClientes.SelectedValue;

                // Calcular el valor de la reparación
                decimal valorReparacion = CalcularValorReparacion(idReparacion);

                Factura nuevaFactura = new Factura
                {
                    IdNegocio = 1, // Suponiendo que el negocio es fijo, cambia esto según tu lógica
                    IdReparacion = idReparacion,
                    IdCliente = idCliente,
                    Valor = valorReparacion,
                    Fecha = DateTime.Now,
                    BdEst = 1
                };

                facturaRepository.AgregarFactura(nuevaFactura);

                // Actualizar el estado de la reparación a "entregado" (idEstado = 4)
                reparacionRepository.ActualizarEstadoReparacion(idReparacion, 4);

                MessageBox.Show("Factura creada exitosamente.");
                VolverALista();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente y una reparación.");
            }
        }


        private decimal CalcularValorReparacion(int idReparacion)
        {
            // Obtener los repuestos de la reparación
            List<ModeloRepuesto> repuestos = reparacionRepository.GetRepuestosPorReparacion(idReparacion);

            // Calcular el valor total sumando los valores de los repuestos
            decimal valorTotal = 0.0m;
            foreach (ModeloRepuesto repuesto in repuestos)
            {
                valorTotal += repuesto.Valor;
            }

            return valorTotal;
        }



        private void VolverALista()
        {
            FacturaControl facturaControl = new FacturaControl(databaseHelper, panelVentana);
            panelVentana.Controls.Clear();
            panelVentana.Controls.Add(facturaControl);
            facturaControl.Dock = DockStyle.Fill;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            VolverALista();
        }

        private void cmbReparaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbClientes_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
