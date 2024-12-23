using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Pokemon.Querys
{
    public class GetCantidadTotalHandler(IPokemonRepository pokemonRepository) : IRequestHandler<GetCantidadTotalQuery, int>
    {
        public async Task<int> Handle(GetCantidadTotalQuery request, CancellationToken cancellationToken)
        {
            return await pokemonRepository.TotalPokemones();
        }
    }
}
