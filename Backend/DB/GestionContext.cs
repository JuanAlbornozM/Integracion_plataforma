using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class GestionContext : DbContext
    {
        public GestionContext(DbContextOptions<GestionContext> options): base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Perfil>().ToTable("Perfil");
        }

    }
}
