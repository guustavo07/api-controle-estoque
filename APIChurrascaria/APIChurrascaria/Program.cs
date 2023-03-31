using APIChurrascaria.Models;
using APIChurrascaria.Repository;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapPost("/Cliente", (Cliente cliente) =>
{
    ClienteRepositorio.AddCliente(cliente);
    return cliente;
});

app.MapGet("/Cliente/{id}", ([FromRoute] int id) =>
{
    var cliente = ClienteRepositorio.GetCliente(id);
    if (cliente != null)
    {
        return Results.Ok(cliente);
    }
    return Results.NotFound();
});

app.MapGet("/Cliente/", () =>
{

});

app.MapPut("/Cliente/{id}", ([FromBody] Cliente clientes, int id) =>
{
    clientes.Id = id;
    Cliente cliente = ClienteRepositorio.UpdateCliente(clientes, id);
    return Results.Ok(clientes);
});

app.MapDelete("/Clientes/{id}", ([FromRoute] int id) =>
{
    bool apagado = ClienteRepositorio.DeleteCliente(id);
    return Results.Ok(apagado);
});

app.MapPost("/Pedidos", (Pedido pedido) => 
{
    PedidoRepositorio.AddPedido(pedido);
    return pedido;
});


app.MapGet("/Pedidos/{id}", ([FromRoute] int id) =>
{
    var pedido = PedidoRepositorio.GetPedidos(id);
    if (pedido != null)
    {
        return Results.Ok(pedido);
    }
    return Results.NotFound();
});

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
