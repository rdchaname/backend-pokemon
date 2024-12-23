using AutoMapper;
using Cibertec.PokemonApi.Domain;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.ConsultaPokemonID
{
    public class ConsultarPokemonByIdMapper : Profile
    {
        public ConsultarPokemonByIdMapper()
        {
            CreateMap<Pokemon, ConsultarPokemonByIdResponse>();
        }
    }
}
