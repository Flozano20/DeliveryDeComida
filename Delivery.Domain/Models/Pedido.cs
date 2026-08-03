using System;

namespace Delivery.Domain.Models
{
    public class Pedido
    {
        public Guid PedidoId { get; set; }
        public string Cliente { get; set; }
        public string Restaurante { get; set; }
        public string Zona { get; set; }
        public int CantidadItems { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }
        public string Estado { get; set; }
        public DateTime FechaHora { get; set; }
    }
}