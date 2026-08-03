using Delivery.Shared.Entities;
using Delivery.Shared.Interfaces;

namespace Delivery.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly List<Pedido> pedidos = new();


        public Task CrearAsync(Pedido pedido)
        {
            pedidos.Add(pedido);

            return Task.CompletedTask;
        }


        public Task<List<Pedido>> ObtenerPedidosAsync()
        {
            return Task.FromResult(pedidos);
        }


        public Task<Pedido?> ObtenerPorIdAsync(Guid id)
        {
            var pedido = pedidos.FirstOrDefault(x => x.PedidoId == id);

            return Task.FromResult(pedido);
        }
    }
}