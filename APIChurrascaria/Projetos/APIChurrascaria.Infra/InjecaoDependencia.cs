using APIChurrascaria.Identity.Data;
using APIChurrascaria.BLL.Interfaces;
using APIChurrascaria.Repository;
using Microsoft.Extensions.DependencyInjection;
using APIChurrascaria.Servicos;
using APIChurrascaria.Data.Repository;
using APIChurrascaria.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace APIChurrascaria.Infra
{
    public static class InjecaoDependencia
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql("Host=localhost;Database=estoquedb;Username=postgres;Password=123456"));

            services.AddDbContext<IdentityDataContext>(options =>
            options.UseNpgsql("Host=localhost;Database=estoquedb;Username=postgres;Password=123456"));

            services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityDataContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IEntradaProdutoRepositorio, EntradaProdutoRepositorio>();
            services.AddScoped<IEstabelecimentoRepositorio, EstabelecimentoRepositorio>();
            services.AddScoped<IEstoqueRepositorio, EstoqueRepositorio>();
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
