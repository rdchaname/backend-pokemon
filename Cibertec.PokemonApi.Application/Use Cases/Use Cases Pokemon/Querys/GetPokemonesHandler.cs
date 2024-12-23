using Cibertec.PokemonApi.Domain;
using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Alumno.Querys
{
    public class GetPokemonesHandler(IPokemonRepository pokemonRepository) : IRequestHandler<GetPokemonesQuery, (IEnumerable<Pokemon>, int)>
    {

        public async Task<(IEnumerable<Pokemon>, int)> Handle(GetPokemonesQuery request, CancellationToken cancellationToken)
        {
            return await pokemonRepository.ObtenerTodosPaginacion(request.NumeroPagina, request.CantidadPorPagina, request.Busqueda, request.Tipo);
        }
    }
}
