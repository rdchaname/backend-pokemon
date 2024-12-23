using AutoMapper;
using Cibertec.PokemonApi.Application.Common;
using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.ConsultaPokemonID
{
    public class ConsultarPokemonByIdRequestHandler(IPokemonRepository _pokemonRepository, IMapper _mapper, ILogger<ConsultarPokemonByIdRequestHandler> logger) : IRequestHandler<ConsultarPokemonByIdRequest, IResult>
    {
        public async Task<IResult> Handle(ConsultarPokemonByIdRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;

            try
            {
                var validador = new ConsultarPokemonByIdValidator();
                var validacionDAtos = validador.Validate(request);

                if (!validacionDAtos.IsValid) throw new ValidationException(validacionDAtos.ToString());
                var pokemonEncontrado = await _pokemonRepository.ObtenerPorId(request.Id);

                if (pokemonEncontrado is not null)
                {
                    response = new SuccessResult<ConsultarPokemonByIdResponse>(_mapper.Map<ConsultarPokemonByIdResponse>(pokemonEncontrado));
                }
                else
                {
                    response = new FailureResult<NotFoundException>("No se encontró pokemón");
                }
            }
            catch (ValidationException ex)
            {
                logger.LogError(ex.Message);
                response = new FailureResult<ValidationException>(ex.Message);
            }
            catch (Common.ApplicationException ex)
            {
                logger.LogError(ex.Message);
                response = new FailureResult<Common.ApplicationException>(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                response = new FailureResult<Exception>(ex.Message);
            }

            return response;
        }
    }
}
