using AutoMapper;
using Cibertec.PokemonApi.Domain;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon
{
    public class RegistrarPokemonMapper : Profile
    {
        public RegistrarPokemonMapper()
        {
            CreateMap<RegistrarPokemonRequest, Pokemon>();
            CreateMap<Pokemon, RegistrarPokemonResponse>();
        }
    }
}
