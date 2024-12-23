using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarUsuarios.RealizarLogin
{
    public class RealizarLoginResponse
    {

        public int Id { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Token { get; set; }
    }
}
