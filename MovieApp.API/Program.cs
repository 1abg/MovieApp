using MediatR;
using Microsoft.OpenApi.Models;
using MovieApp.API.MessageQueue;
using MovieApp.API.MessageQueue.RabbitMQ;
using MovieApp.Application.Extensions;
using MovieApp.Infrastructure.Extensions;
using MovieApp.Persistence.Context;
using MovieApp.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<Guid>(() => new OpenApiSchema { Type = "string", Format = null });
});

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddScoped<IMessageQueueProducer, RabbitMQProducer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
