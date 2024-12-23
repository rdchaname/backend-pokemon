using FluentValidation;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.SincronizarPokemon
{
    public class SincronizarPokemonValidator : AbstractValidator<SincronizarPokemonRequest>
    {
        public SincronizarPokemonValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre del pokemón es requerido");
        }
    }
}
