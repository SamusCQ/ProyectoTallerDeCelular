namespace proyectoFinalPOE.Modelo
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdNegocio { get; set; }
        public int IdReparacion { get; set; }
        public int IdCliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
        public int BdEst { get; set; }
    }
}
