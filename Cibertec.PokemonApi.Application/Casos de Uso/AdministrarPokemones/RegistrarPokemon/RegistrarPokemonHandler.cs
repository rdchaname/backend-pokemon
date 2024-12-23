using AutoMapper;
using Cibertec.PokemonApi.Application.Common;
using Cibertec.PokemonApi.Domain;
using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon
{
    public class RegistrarPokemonHandler(IPokemonRepository _pokemonRepository, IMapper _mapper) : IRequestHandler<RegistrarPokemonRequest, IResult>
    {
        public async Task<IResult> Handle(RegistrarPokemonRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;
            try
            {
                var validador = new RegistrarPokemonValidator();
                var validacionDAtos = validador.Validate(request);
                if (!validacionDAtos.IsValid) throw new ValidationException(validacionDAtos.ToString(";"));

                // verificar si existe pokemon con el mismo nombre
                var entidadPokemon = await _pokemonRepository.ObtenerPorNombre(request.Nombre);

                if (entidadPokemon != null)
                {
                    throw new ValidationException("Ya existe pokemón en base de datos local");
                }

                // Definir la ubicación donde guardar la imagen
                var uploadsFolder = Path.Combine("wwwroot", "images", "pokemons");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder); // Crear la carpeta si no existe
                }

                // Generar un nombre único para la imagen
                var uniqueFileName = "";
                if (request.Imagen != null && request.Imagen.FileName != "")
                {
                    uniqueFileName = $"{Guid.NewGuid()}_{request.Imagen.FileName}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Guardar la imagen en el servidor
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.Imagen.CopyToAsync(fileStream);
                    }
                }

                var entidadDominioPokemon = _mapper.Map<Pokemon>(request);
                if (request.Imagen != null && request.Imagen.FileName != "")
                {
                    entidadDominioPokemon.Imagen = $"/images/pokemons/{uniqueFileName}";
                }
                

                var isOk = await _pokemonRepository.Adicionar(entidadDominioPokemon);
                if (isOk)
                {                  
                    response = new SuccessResult<RegistrarPokemonResponse>(_mapper.Map<RegistrarPokemonResponse>(entidadDominioPokemon));
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
