namespace FerremasProductos.Models
{
    public class CreateProduct
    {
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Codigo { get; set; }
        public string TipoProducto { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
