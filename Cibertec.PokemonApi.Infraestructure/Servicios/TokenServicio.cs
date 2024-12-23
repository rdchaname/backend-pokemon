using Cibertec.PokemonApi.Domain;
using Cibertec.PokemonApi.Domain.Servicios;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cibertec.PokemonApi.Infraestructure.Servicios
{
    public class TokenServicio : ITokenService
    {

        public const string SECRET = "cibertec_pokemonapi_secret_132789132hjk132";
        private const double EXPIRE_HOURS = 1.0;

        public string CreateToken(Usuario usuario)
        {

            var key = Encoding.ASCII.GetBytes(SECRET);
            var tokenHandler = new JwtSecurityTokenHandler();

            var descriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, usuario.Login),
                    }
                    ),
                Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)


            };

            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
