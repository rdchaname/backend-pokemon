using AutoMapper;
using Cibertec.PokemonApi.Domain;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarUsuarios.RealizarLogin
{
    public class RealizarLoginMapper : Profile
    {

        public RealizarLoginMapper()
        {
            CreateMap<Usuario, RealizarLoginResponse>();
        }
    }
}
