using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinalPOE.Modelo
{
    public class Celular
    {
        public int IdCelular { get; set; }
        public int IdCliente { get; set; }
        public int IdModelo { get; set; }
        public int IdColor { get; set; }
        public string NombreCliente { get; set; }
        public int IdMarca { get; set; }
        public string NombreModelo { get; set; }
        public string Color { get; set; }
        public int BdEst { get; set; }
    }
}
