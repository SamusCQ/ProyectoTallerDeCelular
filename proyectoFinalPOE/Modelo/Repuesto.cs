namespace proyectoFinalPOE.Modelo
{
    public class Repuesto
    {
        public int IdRepuesto { get; set; }
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
        public string Descripcion { get; set; }
        public int IdTipo { get; set; }
        public decimal Valor { get; set; }
        public int BdEst { get; set; }
        public int? Cantidad { get; set; }
        public DateTime FechaIngreso { get; set; }

        public string MarcaDescripcion { get; set; }
        public string ModeloDescripcion { get; set; }
        public string TipoDescripcion { get; set; }

        public Repuesto()
        {
            FechaIngreso = DateTime.Now;
        }
    }
}

