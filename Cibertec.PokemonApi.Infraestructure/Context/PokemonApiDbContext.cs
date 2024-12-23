using Cibertec.PokemonApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.PokemonApi.Infraestructure.Context
{
    public class PokemonApiDbContext : DbContext
    {

        public PokemonApiDbContext(DbContextOptions<PokemonApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Login = "admin", Password = "admin", Nombres = "Administrador", Apellidos = "Sistema", Email = "admin@cibertec.edu.pe", Roles = "Admin" },
                new Usuario { Id = 2, Login = "ruben", Password = "ruben", Nombres = "Rubén", Apellidos = "Chanamé", Email = "ruben@cibertec.edu.pe", Roles = "Admin" },
                new Usuario { Id = 3, Login = "abel", Password = "abel", Nombres = "Abel", Apellidos = "Guevara", Email = "abel@cibertec.edu.pe", Roles = "Admin" }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pokemon> Pokemones { get; set; }
    }
}
