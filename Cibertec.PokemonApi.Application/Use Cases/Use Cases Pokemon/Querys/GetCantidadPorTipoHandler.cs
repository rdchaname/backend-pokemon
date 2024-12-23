using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Pokemon.Querys
{
    public class GetCantidadPorTipoHandler(IPokemonRepository pokemonRepository) : IRequestHandler<GetCantidadPorTipoQuery, List<Dictionary<string, object>>>
    {
        public async Task<List<Dictionary<string, object>>> Handle(GetCantidadPorTipoQuery request, CancellationToken cancellationToken)
        {
            return await pokemonRepository.ListarCantidadPorTipo();
        }
    }
}
