using Cibertec.PokemonApi.Application.Common;
using MediatR;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.ConsultaPokemonID
{
    public class ConsultarPokemonByIdRequest: IRequest<IResult>
    {
        public int Id { get; set; }
    }
}
