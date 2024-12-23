using Cibertec.PokemonApi.Application.Common;
using MediatR;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarUsuarios.RealizarLogin
{
    public class RealizarLoginRequest : IRequest<IResult>
    {
        public string Password { get; set; }
        public string Login { get; set; }

    }
}
