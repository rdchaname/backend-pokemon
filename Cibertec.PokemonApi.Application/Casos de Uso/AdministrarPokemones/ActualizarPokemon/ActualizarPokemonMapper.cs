using AutoMapper;
using Cibertec.PokemonApi.Domain;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.ActualizarPokemon
{
    public class ActualizarPokemonMapper : Profile
    {
        public ActualizarPokemonMapper()
        {
            CreateMap<ActualizarPokemonRequest, Pokemon>();
            CreateMap<Pokemon, ActualizarPokemonResponse>();
        }
    }
}
