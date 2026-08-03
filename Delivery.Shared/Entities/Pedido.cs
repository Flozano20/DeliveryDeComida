using System;

namespace Delivery.Shared.Entities
{
    public class Pedido
    {
        public Guid PedidoId { get; set; } = Guid.NewGuid();

        public string Cliente { get; set; } = "";

        public string Restaurante { get; set; } = "";

        public string Zona { get; set; } = "";

        public int CantidadItems { get; set; }

        public decimal Total { get; set; }

        public string MetodoPago { get; set; } = "";

        public string Estado { get; set; } = "Pendiente";

        public DateTime FechaHora { get; set; } = DateTime.Now;
    }
}