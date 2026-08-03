using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Delivery.Shared.Entities;

namespace Delivery.Infrastructure.Kafka
{
    public interface IKafkaProducerService
    {
        Task PublicarPedidoAsync(Pedido pedido);
    }
}