using Cibertec.PokemonApi.Domain;
using Cibertec.PokemonApi.Domain.Repositories;
using Cibertec.PokemonApi.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.PokemonApi.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PokemonApiDbContext _context;

        public UsuarioRepository(PokemonApiDbContext context)
        {
            _context = context;
        }

        public async ValueTask<Usuario> ConsultarByLoginPassword(string login, string password)
        {
            return await _context.Usuarios.Where(item => item.Login == login && item.Password == password).FirstOrDefaultAsync();
        }
    }
}
