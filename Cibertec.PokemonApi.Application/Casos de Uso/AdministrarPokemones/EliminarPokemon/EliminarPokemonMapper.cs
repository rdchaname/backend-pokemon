using AutoMapper;
using Cibertec.PokemonApi.Domain;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon
{
    public class EliminarPokemonMapper : Profile
    {
        public EliminarPokemonMapper()
        {
            CreateMap<EliminarPokemonRequest, Pokemon>();
            CreateMap<Pokemon, EliminarPokemonResponse>();
        }
    }
}
