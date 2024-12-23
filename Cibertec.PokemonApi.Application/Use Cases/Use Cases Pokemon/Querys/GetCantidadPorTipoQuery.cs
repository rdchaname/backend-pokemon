using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Pokemon.Querys
{
    public class GetCantidadPorTipoQuery : IRequest<List<Dictionary<string, object>>>
    {
    }
}
