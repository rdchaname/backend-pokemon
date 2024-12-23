using Cibertec.PokemonApi.Domain.PokeApi;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_PokeApi.Querys
{
    public class GetPokemonesPokeApiQuery : IRequest<List<PokemonResult>>
    {
        public int limit { get; set; }
        public int offset { get; set; }
    }
}
