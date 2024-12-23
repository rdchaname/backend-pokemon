using Cibertec.PokemonApi.Domain.PokeApi;
using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_PokeApi.Querys
{
    public class GetPokemonByNamePokeApiHandler(IPokemonApiRepository pokemonApiRepository) : IRequestHandler<GetPokemonByNamePokeApiQuery, PokemonDetail>
    {
        public async Task<PokemonDetail> Handle(GetPokemonByNamePokeApiQuery request, CancellationToken cancellationToken)
        {
            return await pokemonApiRepository.GetPokemonByNameAsync(request.Name);
        }
    }
}
