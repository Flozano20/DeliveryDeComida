using Delivery.Shared.Entities;

namespace Delivery.Shared.Interfaces
{
    public interface IPedidoRepository
    {
        Task CrearAsync(Pedido pedido);

        Task<List<Pedido>> ObtenerPedidosAsync();

        Task<Pedido?> ObtenerPorIdAsync(Guid id);
    }
}