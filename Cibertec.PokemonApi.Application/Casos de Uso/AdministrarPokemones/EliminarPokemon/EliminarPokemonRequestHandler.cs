using AutoMapper;
using Cibertec.PokemonApi.Application.Common;
using Cibertec.PokemonApi.Domain;
using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon
{
    public class EliminarPokemonRequestHandler(IPokemonRepository _pokemonRepository, IMapper _mapper) : IRequestHandler<EliminarPokemonRequest, IResult>
    {
        public async Task<IResult> Handle(EliminarPokemonRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;
            try
            {
                var validador = new EliminarPokemonValidator();
                var validacionDAtos = validador.Validate(request);
                if (!validacionDAtos.IsValid) throw new ValidationException(validacionDAtos.ToString());

                var entidadDominioProducto = _mapper.Map<Pokemon>(request);

                entidadDominioProducto = await _pokemonRepository.ObtenerPorId(request.Id);
                if (entidadDominioProducto is null)
                {
                    response = new FailureResult<ValidationException>("Pokemón a eliminar no existe");
                    return response;
                }

                var eliminado = await _pokemonRepository.Eliminar(entidadDominioProducto);

                if (eliminado)
                {
                    response = new SuccessResult<EliminarPokemonResponse>(_mapper.Map<EliminarPokemonResponse>(entidadDominioProducto));
                }
                else
                {
                    throw new Common.ApplicationException("No se pudo eliminar el pokemón");
                }
            }
            catch (ValidationException ex)
            {
                response = new FailureResult<ValidationException>(ex.Message);


            }
            catch (Common.ApplicationException ex)
            {
                response = new FailureResult<Common.ApplicationException>(ex.Message);
            }
            catch (Exception ex)
            {
                response = new FailureResult<Exception>(ex.Message);
            }

            return response;
        }
    }
}
