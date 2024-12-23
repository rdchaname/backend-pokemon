using FluentValidation;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.ActualizarPokemon
{
    public class ActualizarPokemonValidator : AbstractValidator<ActualizarPokemonRequest>
    {
        public ActualizarPokemonValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre del pokemón es requerido");
            RuleFor(x => x.Tipo).NotEmpty().WithMessage("El tipo del pokemón es requerido");
        }
    }
}
