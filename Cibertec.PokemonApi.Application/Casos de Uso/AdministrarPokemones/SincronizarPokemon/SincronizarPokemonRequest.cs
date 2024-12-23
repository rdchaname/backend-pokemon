using Cibertec.PokemonApi.Application.Common;
using MediatR;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.SincronizarPokemon
{
    public class SincronizarPokemonRequest : IRequest<IResult>
    {
        public string Name { get; set; }
    }
}
