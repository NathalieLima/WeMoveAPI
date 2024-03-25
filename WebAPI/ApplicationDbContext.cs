using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace PersonsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<ViagemCaronaOferta> ViagensCaronaOferta { get; set; }
        public DbSet<ViagemOnibus> ViagensOnibus { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Onibus> Onibus { get; set; }
        public DbSet<TransportePrivados> TransportesPrivados { get; set; }
        public DbSet<EmpresaOnibus> EmpresasOnibus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(u => new { u.Id, u.Email });
        }

    }
}
