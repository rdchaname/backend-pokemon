using Cibertec.PokemonApi.Domain.PokeApi;
using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_PokeApi.Querys
{
    public class GetPokemonesPokeApiHandler(IPokemonApiRepository pokemonApiRepository): IRequestHandler<GetPokemonesPokeApiQuery, List<PokemonResult>>
    {
        public async Task<List<PokemonResult>> Handle(GetPokemonesPokeApiQuery request, CancellationToken cancellationToken)
        {
            return await pokemonApiRepository.GetPokemonListAsync(request.limit, request.offset);
        }
    }
}
