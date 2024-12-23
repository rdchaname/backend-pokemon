namespace Cibertec.PokemonApi.Application.Common
{
    public class NoAutorizadoException : Exception
    {
        public NoAutorizadoException() { }

        public NoAutorizadoException(string message) : base(message) { }

        public NoAutorizadoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
