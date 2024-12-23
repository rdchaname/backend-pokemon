using Cibertec.PokemonApi.Domain;
using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Alumno.Querys
{
    public class GetPokemonByIdHandler(IPokemonRepository pokemonRepository) : IRequestHandler<GetPokemonByIdQuery, Pokemon>
    {

        public async Task<Pokemon> Handle(GetPokemonByIdQuery request, CancellationToken cancellationToken)
        {
            return await pokemonRepository.ObtenerPorId(request.Id);
        }
    }
}
