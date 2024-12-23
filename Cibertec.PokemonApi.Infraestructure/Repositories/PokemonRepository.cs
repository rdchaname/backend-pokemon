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

        public async Task<(IEnumerable<Pokemon>, int)> ObtenerTodosPaginacion(int numeroPagina = 1, int cantidadPorPagina = 20, string busqueda = "", string tipo = "")
        {
            var query = _context.Pokemones.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                // Aplica el filtro LIKE en la columna tipo
                query = query.Where(p => EF.Functions.Like(p.Nombre, $"%{busqueda}%"));
            }

            if (!string.IsNullOrEmpty(tipo))
            {
                // Aplica el filtro LIKE en la columna tipo
                query = query.Where(p => EF.Functions.Like(p.Tipo, $"%{tipo}%"));
            }

            var totalPokemones = await _context.Pokemones.CountAsync();

            var pokemones = await query
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

        public async Task<int> TotalPokemones()
        {
            var totalPokemones = await _context.Pokemones.CountAsync();
            return totalPokemones;
        }

        public async Task<int> CantidadPorTipo(string tipo)
        {
            var totalPokemones = await _context.Pokemones.Where(p => p.Tipo == tipo).CountAsync();
            return totalPokemones;
        }

        public async Task<List<Dictionary<string, object>>> ListarCantidadPorTipo()
        {
            var cantidadPorTipo = await _context.Pokemones
                   .GroupBy(p => p.Tipo) // Agrupa por el nombre
                   .Select(g => new Dictionary<string, object>
                   {
                        { "Nombre", g.Key },       // "Nombre" como clave y el valor del grupo (g.Key)
                        { "Cantidad", g.Count() }  // "Cantidad" como clave y la cantidad de productos
                   })
                   .ToListAsync();
            return cantidadPorTipo;
        }

        public async Task<decimal> PromedioPoderCombate()
        {
            var totalPokemones = await _context.Pokemones.CountAsync();
            if (totalPokemones == 0)
            {
                return (decimal)0.00;
            }
            var promedio = await _context.Pokemones
                        .Where(p => p.PoderCombate != null)
                        .Select(p => p.PoderCombate)
                        .AverageAsync();
            return (decimal)promedio;
        }

        public async Task<IEnumerable<string>> ObtenerTipos()
        {
            return await _context.Pokemones.Select(p => p.Tipo).Distinct().ToListAsync();
        }
    }
}
