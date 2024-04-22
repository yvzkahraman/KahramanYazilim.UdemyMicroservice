using InventoryService.API.Consumers;
using InventoryService.Data.Repositories;
using MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(Assembly.GetExecutingAssembly());
    x.UsingRabbitMq();
});

var control = Bus.Factory.CreateUsingRabbitMq(x =>
{
    x.ReceiveEndpoint("market-created-event", e =>
    {
        e.Consumer<MarketCreatedConsumer>();
    });
});

await control.StartAsync();

builder.Services.AddScoped<ItemRepository>();
builder.Services.AddScoped<InventoryRepository>();
builder.Services.AddScoped<ItemInventoryRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
