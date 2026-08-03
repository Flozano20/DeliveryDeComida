using System.Text.Json;
using Confluent.Kafka;
using Delivery.Shared.Entities;

namespace Delivery.Infrastructure.Kafka
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IProducer<string, string> _producer;

        public KafkaProducerService()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<string, string>(config)
                .Build();
        }

        public async Task PublicarPedidoAsync(Pedido pedido)
        {
            string mensaje = JsonSerializer.Serialize(pedido);

            await _producer.ProduceAsync(
                "pedidos-topic",
                new Message<string, string>
                {
                    Key = pedido.PedidoId.ToString(),
                    Value = mensaje
                });
        }
    }
}