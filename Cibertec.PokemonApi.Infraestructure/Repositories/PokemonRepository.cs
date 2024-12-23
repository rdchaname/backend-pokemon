using Cibertec.PokemonApi.Domain;
using Cibertec.PokemonApi.Domain.Repositories;
using Cibertec.PokemonApi.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.PokemonApi.Infraestructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {

        private readonly PokemonApiDbContext _context;

        public PokemonRepository(PokemonApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pokemon>> ObtenerTodos()
        {
            return await _context.Pokemones.ToListAsync();
        }

        public async Task<(IEnumerable<Pokemon>, int)> ObtenerTodosPaginacion(int numeroPagina = 1, int cantidadPorPagina = 20)
        {
            var totalPokemones = await _context.Pokemones.CountAsync();

            var pokemones = await _context.Pokemones
                .Skip((numeroPagina - 1) * cantidadPorPagina)
                .Take(cantidadPorPagina)
                .ToListAsync();
            return (pokemones, totalPokemones);
        }

        public async Task<Pokemon> ObtenerPorId(int id)
        {
            return await _context.Pokemones.FindAsync(id);
        }

        public async Task<Pokemon> ObtenerPorNombre(string nombre)
        {
            return await _context.Pokemones.FirstOrDefaultAsync(p => p.Nombre == nombre);
        }

        public async Task<bool> Adicionar(Pokemon pokemon)
        {
            _context.Pokemones.Add(pokemon);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Pokemon pokemon)
        {
            _context.Pokemones.Update(pokemon);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(Pokemon pokemon)
        {
            _context.Pokemones.Remove(pokemon);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
