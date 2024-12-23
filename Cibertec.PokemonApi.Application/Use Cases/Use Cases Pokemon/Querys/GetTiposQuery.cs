using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Pokemon.Querys
{
    public class GetTiposQuery : IRequest<IEnumerable<string>>
    {
    }
}
