using Cibertec.PokemonApi.Domain;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Alumno.Querys
{
    public class GetPokemonByIdQuery : IRequest<Pokemon>
    {
        public int Id { get; set; }
    }
}
