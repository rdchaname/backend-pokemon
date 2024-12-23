using Cibertec.PokemonApi.Domain.PokeApi;

namespace Cibertec.PokemonApi.Domain.Servicios
{
    public interface IPokeApiService
    {

        Task<List<PokemonResult>> GetPokemonListAsync(int limit = 20, int offset = 0);
        Task<PokemonDetail> GetPokemonByNameAsync(string name);
        Task<string> DescargarYGuardarImagen(string url, string name);
    }
}
