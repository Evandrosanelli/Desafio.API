using Desafio.API.Interfaces.Repository;
using Desafio.API.Interfaces.Service;
using Desafio.API.Repositories;
using Desafio.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PostgreContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Repositories
builder.Services.AddScoped<IStatusPedidoRepository,StatusPedidoRepository>();
builder.Services.AddScoped<IStatusDroneRepository,StatusDroneRepository>();
builder.Services.AddScoped<IPedidoRepository,PedidoRepository>();
builder.Services.AddScoped<IDroneRepository,DroneRepository>();
#endregion

#region Services
builder.Services.AddScoped<IStatusPedidoService, StatusPedidoService>();
builder.Services.AddScoped<IStatusDroneService, StatusDroneService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IDroneService, DroneService>();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();