//usavel
using APIChurrascaria.Controllers;
using APIChurrascaria.Identity.Data;
using APIChurrascaria.Identity.Interfaces;
using APIChurrascaria.Identity.Services;
using APIChurrascaria.Infra.Data;
using APIChurrascaria.Repository;
using APIChurrascaria.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseNpgsql("Host=localhost;Database=estoquedb;Username=postgres;Password=123456"));

builder.Services.AddDbContext<IdentityDataContext>(options =>
 options.UseNpgsql("Host=localhost;Database=estoquedb;Username=postgres;Password=123456"));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityDataContext>()
    .AddDefaultTokenProviders();

//injeção de dependencias
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IEntradaProdutoRepositorio, EntradaProdutoRepositorio>();
builder.Services.AddScoped<IEstabelecimentoRepositorio, EstabelecimentoRepositorio>();
builder.Services.AddScoped<IEstoqueRepositorio, EstoqueRepositorio>();
builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();


builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddVersioning();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var apiVersionProvider = app.Services.GetService<IApiVersionDescriptionProvider>();
        if (apiVersionProvider == null)
            throw new ArgumentException("API Versioning not registered.");

        foreach (var description in apiVersionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            description.GroupName);
        }
        options.RoutePrefix = "swagger";

        options.DocExpansion(DocExpansion.List);
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(builder => builder
    .SetIsOriginAllowed(orign => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());


app.Run();
