using proyectoFinalPOE.Repositorio;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Controlador;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyectoFinalPOE.Vista
{
    public partial class ClienteControl : UserControl
    {
        private ClienteRepository clienteRepository;

        public ClienteControl(DatabaseHelper databaseHelper)
        {
            InitializeComponent();
            clienteRepository = new ClienteRepository(databaseHelper);
            LoadClientes();
        }

        private void LoadClientes()
        {
            List<Cliente> clientes = clienteRepository.GetClientes();
            dgvClientes.DataSource = clientes;
        }
    }
}
