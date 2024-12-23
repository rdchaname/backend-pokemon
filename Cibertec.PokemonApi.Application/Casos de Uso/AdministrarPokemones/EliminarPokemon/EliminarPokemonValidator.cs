using FluentValidation;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon
{
    public class EliminarPokemonValidator : AbstractValidator<EliminarPokemonRequest>
    {
        public EliminarPokemonValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El Id del pokemón es requerido");
        }
    }
}
