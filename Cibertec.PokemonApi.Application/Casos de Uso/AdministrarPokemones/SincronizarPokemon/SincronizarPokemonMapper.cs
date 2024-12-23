using AutoMapper;
using Cibertec.PokemonApi.Domain;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.SincronizarPokemon
{
    public class SincronizarPokemonMapper : Profile
    {
        public SincronizarPokemonMapper()
        {
            CreateMap<Pokemon, SincronizarPokemonResponse>();
        }
    }
}
