using Delivery.Shared.Entities;
using Delivery.Infrastructure.Kafka;

namespace Delivery.Api.Services
{
    public class PedidoGeneratorService
    {
        private readonly IKafkaProducerService _kafkaProducer;


        public PedidoGeneratorService(
            IKafkaProducerService kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }



        // Envía un pedido individual
        public async Task GenerarPedidoAsync(Pedido pedido)
        {
            await _kafkaProducer.PublicarPedidoAsync(pedido);
        }



        // Genera múltiples pedidos
        public async Task GenerarPedidosMasivos(
            int cantidad,
            string zona)
        {

            for (int i = 1; i <= cantidad; i++)
            {

                var pedido = new Pedido
                {
                    PedidoId = Guid.NewGuid(),

                    Cliente = $"Cliente {i}",

                    Restaurante = $"Restaurante {i}",

                    Zona = zona,

                    CantidadItems = Random.Shared.Next(1, 6),

                    Total = Random.Shared.Next(50, 500),

                    MetodoPago = "Tarjeta",

                    Estado = "Pendiente",

                    FechaHora = DateTime.Now
                };


                await _kafkaProducer.PublicarPedidoAsync(pedido);
            }
        }
    }
}