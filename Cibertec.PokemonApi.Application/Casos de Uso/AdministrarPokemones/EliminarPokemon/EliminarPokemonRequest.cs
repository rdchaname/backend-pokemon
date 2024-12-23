using Cibertec.PokemonApi.Application.Common;
using MediatR;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon
{
    public class EliminarPokemonRequest : IRequest<IResult>
    {
        public int Id { get; set; }
    }
}
