using Desafio.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Repositories
{
    public class PostgreContext : DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options) { }

        #region Tabelas

        public DbSet<StatusPedido> StatusPedido { get; set; }
        public DbSet<StatusDrone> StatusDrone { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Entrega> Entrega { get; set; }
        public DbSet<Drone> Drone { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=banco;Username=docker;Password=docker");
            }
        }
    }
}
