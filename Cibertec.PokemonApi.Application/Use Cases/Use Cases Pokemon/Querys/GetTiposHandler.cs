using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Pokemon.Querys
{
    public class GetTiposHandler(IPokemonRepository pokemonRepository) : IRequestHandler<GetTiposQuery, IEnumerable<string>>
    {
        public async Task<IEnumerable<string>> Handle(GetTiposQuery request, CancellationToken cancellationToken)
        {
            return await pokemonRepository.ObtenerTipos();
        }
    }
}
