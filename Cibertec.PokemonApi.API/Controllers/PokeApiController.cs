using Cibertec.PokemonApi.API.Common.Filters;
using Cibertec.PokemonApi.Application.Common;
using Cibertec.PokemonApi.Application.Use_Cases.Use_PokeApi.Querys;
using Cibertec.PokemonApi.Domain.PokeApi;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.PokemonApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter<CustomResultFilter>]
    public class PokeApiController(IMediator _mediator) : ControllerBase
    {
        //retornar todos los pokemones
        [HttpGet]
        public async Task<ActionResult> GetPokemonesPokeApi([FromQuery] GetPokemonesPokeApiQuery request)
        {
            var pokemones = await _mediator.Send(request);
            return new ObjectResult(new SuccessResult<List<PokemonResult>>(pokemones));
        }
    }
}
