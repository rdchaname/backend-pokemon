using Cibertec.PokemonApi.Domain.PokeApi;
using Cibertec.PokemonApi.Domain.Repositories;
using Cibertec.PokemonApi.Infraestructure.Servicios;

namespace Cibertec.PokemonApi.Infraestructure.Repositories
{
    public class PokemonApiRepository: IPokemonApiRepository
    {

        private readonly PokeApiService _pokeApiService;

        public PokemonApiRepository(PokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

        public async Task<PokemonDetail> GetPokemonByNameAsync(string name)
        {
            return await _pokeApiService.GetPokemonByNameAsync(name);
        }

        public async Task<List<PokemonResult>> GetPokemonListAsync(int limit, int offset)
        {
            return await _pokeApiService.GetPokemonListAsync(limit, offset);
        }
        
        public async Task<string> DescargarYGuardarImagen(string url, string name)
        {
            return await _pokeApiService.DescargarYGuardarImagen(url, name);
        }

    }
}
