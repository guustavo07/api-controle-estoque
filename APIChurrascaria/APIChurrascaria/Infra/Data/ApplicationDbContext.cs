using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;

namespace APIChurrascaria.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EntradaProduto> EntradasProdutos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=estoquedb;Username=postgres;Password=123456");


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           /* base.OnModelCreating(builder);

            builder.Ignore<Notification>();

            builder.Entity<Cliente>()
                .Property(p => p.Name).IsRequired();
            builder.Entity<Cliente>()
                .Property(p => p.Description).HasMaxLength(255);

            builder.Entity<Category>()
                .Property(c => c.Name).IsRequired();*/
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>()
                .HaveMaxLength(100);
        }
    }
}
