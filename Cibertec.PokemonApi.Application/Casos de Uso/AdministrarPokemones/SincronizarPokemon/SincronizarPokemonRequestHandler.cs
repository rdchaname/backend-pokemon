using AutoMapper;
using Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon;
using Cibertec.PokemonApi.Application.Common;
using Cibertec.PokemonApi.Domain;
using Cibertec.PokemonApi.Domain.PokeApi;
using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.SincronizarPokemon
{
    public class SincronizarPokemonRequestHandler(IPokemonRepository _pokemonRepository, IPokemonApiRepository _pokemonApiRepository, IMapper _mapper) : IRequestHandler<SincronizarPokemonRequest, IResult>
    {
        public async Task<IResult> Handle(SincronizarPokemonRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;
            try
            {
                var validador = new SincronizarPokemonValidator();
                var validacionDAtos = validador.Validate(request);
                if (!validacionDAtos.IsValid) throw new ValidationException(validacionDAtos.ToString(";"));

                // verificar si existe pokemon con el mismo nombre
                var entidadPokemon = await _pokemonRepository.ObtenerPorNombre(request.Name);

                if (entidadPokemon != null)
                {
                    throw new ValidationException("Ya existe pokemón en base de datos local");
                }

                var pokemonDetail = await _pokemonApiRepository.GetPokemonByNameAsync(request.Name);

                if (pokemonDetail == null)
                {
                    throw new ValidationException("No existe pokemon en POKE API");
                }

                entidadPokemon = new Pokemon();
                entidadPokemon.Nombre = pokemonDetail.Name;
                entidadPokemon.Tipo = pokemonDetail.Type;
                entidadPokemon.PoderCombate = 100;
                entidadPokemon.Imagen = await _pokemonApiRepository.DescargarYGuardarImagen(pokemonDetail.Imagen, pokemonDetail.Name);

                var isOk = await _pokemonRepository.Adicionar(entidadPokemon);
                if (isOk)
                {
                    response = new SuccessResult<SincronizarPokemonResponse>(_mapper.Map<SincronizarPokemonResponse>(entidadPokemon));
                }
                else
                {
                    throw new Common.ApplicationException("Error al registrar el pokemon");
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
