using Cibertec.PokemonApi.Domain;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Alumno.Querys
{
    public class GetPokemonesQuery : IRequest<(IEnumerable<Pokemon>, int)>
    {
        public int NumeroPagina { get; set; }
        public int CantidadPorPagina { get; set; }
        public string? Busqueda { get; set; }
        public string? Tipo { get; set; }
    }
}
