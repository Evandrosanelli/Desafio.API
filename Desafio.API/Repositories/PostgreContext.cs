using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Repositories
{
    public class PostgreContext : DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options) { }

        #region Tabelas
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
