using Cibertec.PokemonApi.Domain.Repositories;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Pokemon.Commands
{
    public class AddPokemonHandler(IPokemonRepository pokemonRepository) : IRequestHandler<AddPokemonCommand>
    {
        public async Task Handle(AddPokemonCommand request, CancellationToken cancellationToken)
        {
            await pokemonRepository.Adicionar(request.pokemon);
        }
    }
}
