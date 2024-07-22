using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinalPOE.Modelo
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public int? IdCliente { get; set; }  // Nullable to handle NULL values
        public int? IdTecnico { get; set; }  // Nullable to handle NULL values
        public int BdEst { get; set; }
    }
}

