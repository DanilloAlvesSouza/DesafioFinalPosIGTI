using ApiModuloFinal.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiModuloFinal.Repository
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                "Data Source=laptop-7d0espf2\\sqlexpress;Initial Catalog=igti; Integrated Security=True; TrustServerCertificate=True;");
    }
}
