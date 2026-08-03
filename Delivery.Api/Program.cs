using Delivery.Api.Services;
using Delivery.Infrastructure.Kafka;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IKafkaProducerService, KafkaProducerService>();

builder.Services.AddScoped<PedidoGeneratorService>();



var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();


app.Run();