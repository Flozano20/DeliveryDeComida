using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Worker.Consumers
{
    public class PedidoConsumerService : BackgroundService
    {
        private readonly ILogger<PedidoConsumerService> _logger;

        public PedidoConsumerService(
            ILogger<PedidoConsumerService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(
                    "Consumer de pedidos ejecutándose...");

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}