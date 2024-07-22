using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinalPOE.Modelo
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NuCedula { get; set; }
        public string NuCelular { get; set; }
        public string Correo { get; set; }
        public int BdEst { get; set; }
        public string NombreCompleto { get; set; }
    }
}
