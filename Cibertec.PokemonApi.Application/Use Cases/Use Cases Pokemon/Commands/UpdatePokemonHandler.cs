using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Pokemon.Commands
{
    public class UpdatePokemonHandler(IPokemonRepository pokemonRepository) : IRequestHandler<UpdatePokemonCommand>
    {
        public async Task Handle(UpdatePokemonCommand request, CancellationToken cancellationToken)
        {
            await pokemonRepository.Modificar(request.pokemon);
        }
    }
}
