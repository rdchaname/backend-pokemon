using Cibertec.PokemonApi.Domain.PokeApi;

namespace Cibertec.PokemonApi.Domain.Repositories
{
    public interface IPokemonApiRepository
    {
        Task<List<PokemonResult>> GetPokemonListAsync(int limit, int offset);
        Task<PokemonDetail> GetPokemonByNameAsync(string name);
        Task<string> DescargarYGuardarImagen(string url, string name);
    }
}
