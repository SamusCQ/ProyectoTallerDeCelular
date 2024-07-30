using System;

namespace proyectoFinalPOE.Modelo
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NuCedula { get; set; }
        public string NuCelular { get; set; }
        public string Correo { get; set; }
        public int BdEst { get; set; }
        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {Apellido}";
            }
        }
    }
}
