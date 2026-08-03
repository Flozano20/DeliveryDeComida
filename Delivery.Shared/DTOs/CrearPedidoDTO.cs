namespace Delivery.Shared.DTOs
{
    public class CrearPedidoDto
    {
        public string Cliente { get; set; }
        public string Restaurante { get; set; }
        public string Zona { get; set; }
        public int CantidadItems { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }
    }
}