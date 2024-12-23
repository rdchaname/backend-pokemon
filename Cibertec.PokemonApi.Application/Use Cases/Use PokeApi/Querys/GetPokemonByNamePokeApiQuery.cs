using Cibertec.PokemonApi.Domain.PokeApi;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_PokeApi.Querys
{
    public class GetPokemonByNamePokeApiQuery : IRequest<PokemonDetail>
    {
        public string Name { get; set; }
    }
}
