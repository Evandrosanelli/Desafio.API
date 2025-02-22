using Desafio.API.Entities;
using Desafio.API.Repositories.Seeds;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var drones = DorneSeeds.GetSeedsDrones();
            var pedidos = PedidoSeeds.GetSeedsPedidos();
            var statusDrones = StatusSeeds.GetSeedsStatusDrone();
            var statusPedidos = StatusSeeds.GetSeedsStatusPedido();

            modelBuilder.Entity<Drone>().HasData(drones);
            modelBuilder.Entity<Pedido>().HasData(pedidos);
            modelBuilder.Entity<StatusDrone>().HasData(statusDrones);
            modelBuilder.Entity<StatusPedido>().HasData(statusPedidos);
        }
    }
}
