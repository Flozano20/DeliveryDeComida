using Microsoft.AspNetCore.Mvc;
using Delivery.Shared.DTOs;
using Delivery.Infrastructure.Kafka;
using Delivery.Api.Services;
using Delivery.Shared.Entities;

namespace Delivery.Api.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly IKafkaProducerService _kafkaProducer;
        private readonly PedidoGeneratorService _pedidoGenerator;

        public PedidosController(
            IKafkaProducerService kafkaProducer,
            PedidoGeneratorService pedidoGenerator)
        {
            _kafkaProducer = kafkaProducer;
            _pedidoGenerator = pedidoGenerator;
        }


        // Crear un pedido individual
        [HttpPost]
        public async Task<IActionResult> CrearPedido([FromBody] CrearPedidoDto dto)
        {
            var pedido = new Pedido
            {
                PedidoId = Guid.NewGuid(),
                Cliente = dto.Cliente,
                Restaurante = dto.Restaurante,
                Zona = dto.Zona,
                CantidadItems = dto.CantidadItems,
                Total = dto.Total,
                MetodoPago = dto.MetodoPago,
                Estado = "Pendiente",
                FechaHora = DateTime.Now
            };


            await _kafkaProducer.PublicarPedidoAsync(pedido);


            return Ok(new
            {
                mensaje = "Pedido enviado correctamente a Kafka",
                pedidoId = pedido.PedidoId
            });
        }



        // Crear pedidos masivos
        [HttpPost("masivo")]
        public async Task<IActionResult> CrearPedidosMasivos(
            [FromBody] PedidoMasivoDto dto)
        {

            await _pedidoGenerator.GenerarPedidosMasivos(
                dto.Cantidad,
                dto.Zona
            );


            return Ok(new
            {
                mensaje = "Pedidos masivos enviados a Kafka",
                cantidad = dto.Cantidad
            });                                                     
        }
    }
}