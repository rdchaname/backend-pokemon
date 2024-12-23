namespace Cibertec.PokemonApi.Domain.Servicios
{
    public interface ITokenService
    {
        string CreateToken(Usuario usuario);
    }
}
