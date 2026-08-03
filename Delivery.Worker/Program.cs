using Delivery.Worker.Consumers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<PedidoConsumerService>();

var host = builder.Build();

host.Run();