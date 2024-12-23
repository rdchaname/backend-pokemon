using FluentValidation;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.ConsultaPokemonID
{
    public class ConsultarPokemonByIdValidator : AbstractValidator<ConsultarPokemonByIdRequest>
    {
        public ConsultarPokemonByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El Id del pokemón es requerido");
        }
    }
}
