using AutoMapper;
using Cibertec.PokemonApi.Application.Common;
using Cibertec.PokemonApi.Domain;
using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.ActualizarPokemon
{
    public class ActualizarPokemonRequestHandler(IPokemonRepository _pokemonRepository, IMapper _mapper) : IRequestHandler<ActualizarPokemonRequest, IResult>
    {
        public async Task<IResult> Handle(ActualizarPokemonRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;
            try
            {
                var validador = new ActualizarPokemonValidator();
                var validacionDAtos = validador.Validate(request);
                if (!validacionDAtos.IsValid) throw new ValidationException(validacionDAtos.ToString(";"));

                // validar que pokemon a actualizar exista
                var pokemonEncontrado = await _pokemonRepository.ObtenerPorId(request.Id);
                if (pokemonEncontrado == null)
                {
                    throw new NotFoundException("No existe pokemon a modificar");
                }

                // verificar si existe pokemon con el mismo nombre pero que no sea el mismo
                pokemonEncontrado = await _pokemonRepository.ObtenerPorNombre(request.Nombre);
                if (pokemonEncontrado != null && request.Id != pokemonEncontrado.Id)
                {
                    throw new ValidationException("Ya existe otro pokemón con el mismo nombre en la base de datos local");
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

                Console.WriteLine("--------------");
                Console.WriteLine(request.Nombre);
                Console.WriteLine("--------------");
                if (pokemonEncontrado is null)
                {
                    pokemonEncontrado = await _pokemonRepository.ObtenerPorId(request.Id);
                }
                pokemonEncontrado.Nombre = request.Nombre;
                pokemonEncontrado.Tipo = request.Tipo;
                pokemonEncontrado.PoderCombate = request.PoderCombate;
                if (request.Imagen != null && request.Imagen.FileName != "")
                {
                    pokemonEncontrado.Imagen = $"/images/pokemons/{uniqueFileName}";
                }

                var isOk = await _pokemonRepository.Modificar(pokemonEncontrado);
                if (isOk)
                {
                    response = new SuccessResult<ActualizarPokemonResponse>(_mapper.Map<ActualizarPokemonResponse>(pokemonEncontrado));
                }
                else
                {
                    throw new Common.ApplicationException("Error al actualizar el pokemón");
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
