namespace Cibertec.PokemonApi.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        ValueTask<Usuario> ConsultarByLoginPassword(string login, string password);
    }
}
