using Cibertec.PokemonApi.API.Common.Filters;
using Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.ActualizarPokemon;
using Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.ConsultaPokemonID;
using Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon;
using Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon;
using Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.SincronizarPokemon;
using Cibertec.PokemonApi.Application.Common;
using Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Alumno.Querys;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.PokemonApi.API.Controllers
{
    [Route("api/pokemon")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(CustomResultFilter))]
    public class PokemonController(IMediator _mediator) : ControllerBase
    {
        //retornar todos los pokemones
        [HttpGet]
        public async Task<ActionResult> GetPokemones([FromQuery] GetPokemonesQuery request)
        {
            var pokemones = await _mediator.Send(request);
            var response = new
            {
                data = pokemones.Item1,
                total = pokemones.Item2
            };
            return new ObjectResult(new SuccessResult<Object>(response));
        }

        // retornar un pokemon por id
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetPokemonById([FromRoute] ConsultarPokemonByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return new ObjectResult(response);
        }

        // registrar nuevo pokemon
        [HttpPost]
        public async Task<ActionResult> AgregarPokemon([FromForm] RegistrarPokemonRequest pokemon)
        {
            if (pokemon == null)
            {
                return new ObjectResult(new FailureResult<ValidationException>("Debe enviar los datos"));
            }

            if (pokemon.Imagen != null && pokemon.Imagen.Length == 0)
            {
                return BadRequest("Debe subir una imagen válida.");
            }

            RegistrarPokemonResponse.SetBaseUrl($"{Request.Scheme}://{Request.Host}");

            var response = await _mediator.Send(pokemon);
            return new ObjectResult(response);
        }

        // sincronizar pokemon
        [HttpPost("sincronizar/{Name}")]
        public async Task<ActionResult> SincronizarPokemon([FromRoute] SincronizarPokemonRequest request)
        {
            if (request == null)
            {
                return new ObjectResult(new FailureResult<ValidationException>("Debe enviar los datos"));
            }
            var response = await _mediator.Send(request);
            return new ObjectResult(response);
        }

        // actulizar un pokemon por id
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdatePokemon(int Id, [FromForm] ActualizarPokemonRequest request)
        {
            if (request == null)
            {
                return new ObjectResult(new FailureResult<ValidationException>("Debe enviar los datos"));
            }
            request.Id = Id;
            var response = await _mediator.Send(request);
            return new ObjectResult(response);
        }

        //// eliminar un pokemon por id
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeletePokemon([FromRoute] EliminarPokemonRequest request)
        {
            if (request == null)
            {
                return new ObjectResult(new FailureResult<ValidationException>("Debe enviar los datos"));
            }
            var response = await _mediator.Send(request);
            return new ObjectResult(response);
        }
    }
}
