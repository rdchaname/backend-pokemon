using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Pokemon.Querys
{
    public class GetPromedioPoderCombateHandler(IPokemonRepository pokemonRepository) : IRequestHandler<GetPromedioPoderCombateQuery, decimal>
    {
        public async Task<decimal> Handle(GetPromedioPoderCombateQuery request, CancellationToken cancellationToken)
        {
            return await pokemonRepository.PromedioPoderCombate();
        }
    }
}
