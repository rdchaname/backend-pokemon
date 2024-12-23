using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Pokemon.Commands
{
    public class DeletePokemonHandler(IPokemonRepository pokemonRepository) : IRequestHandler<DeletePokemonCommand>
    {
        public async Task Handle(DeletePokemonCommand request, CancellationToken cancellationToken)
        {
            await pokemonRepository.Eliminar(request.pokemon);
        }
    }
}
