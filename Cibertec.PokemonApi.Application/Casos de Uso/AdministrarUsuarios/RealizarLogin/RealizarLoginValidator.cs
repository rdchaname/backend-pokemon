using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarUsuarios.RealizarLogin
{
    public class RealizarLoginValidator : AbstractValidator<RealizarLoginRequest>
    {
        public RealizarLoginValidator()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage("El campo Login es obligatorio");
            RuleFor(x => x.Password).NotEmpty().WithMessage("El campo Password es obligatorio");
        }
    }
}
