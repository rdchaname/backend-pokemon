using Cibertec.PokemonApi.API.Common.Filters;
using Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarUsuarios.RealizarLogin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Cibertec.PokemonApi.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [TypeFilter<CustomResultFilter>]
    public class AutenticacionController(IMediator mediator) : ControllerBase
    {

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] RealizarLoginRequest request)
        {
            var response = await mediator.Send(request);
            return new ObjectResult(response);

        }
    }
}
