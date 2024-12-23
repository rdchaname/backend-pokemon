using FluentValidation;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon
{
    public class RegistrarPokemonValidator : AbstractValidator<RegistrarPokemonRequest>
    {
        public RegistrarPokemonValidator() {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre del pokemón es requerido");
            RuleFor(x => x.Tipo).NotEmpty().WithMessage("El tipo del pokemón es requerido");
        }
    }
}
