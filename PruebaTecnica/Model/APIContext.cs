using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Model
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) :
            base(options)
        { }

        public DbSet<Estados> Estados { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Solicitud> Solicitud { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var estados = new Estados[] {
                new Estados() { id = 1, estado = "Abiertas" },
                new Estados() { id = 2, estado = "Aprobadas" },
                new Estados() { id = 3, estado = "Canceladas" }
            };

            modelBuilder.Entity<Estados>().HasData(estados);

            modelBuilder.Entity<Personas>().HasKey(k => k.id);
            modelBuilder.Entity<Solicitud>().HasKey(k => k.id);

            modelBuilder.Entity<Personas>().Property(p => p.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Solicitud>().Property(p => p.id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Solicitud>().HasOne(p => p.Persona);
            modelBuilder.Entity<Solicitud>().HasOne(e => e.Estado);
        }
    }
}
