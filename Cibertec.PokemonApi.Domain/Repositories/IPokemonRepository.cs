namespace Cibertec.PokemonApi.Domain.Repositories
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> ObtenerTodos();
        Task<(IEnumerable<Pokemon>, int)> ObtenerTodosPaginacion(int numeroPagina, int cantidadPorPagina, string busqueda, string tipo);
        Task<Pokemon> ObtenerPorId(int id);
        Task<Pokemon> ObtenerPorNombre(string nombre);
        Task<bool> Adicionar(Pokemon pokemon);
        Task<bool> Modificar(Pokemon pokemon);
        Task<bool> Eliminar(Pokemon pokemon);
        Task<int> TotalPokemones();
        Task<int> CantidadPorTipo(string tipo);
        Task<List<Dictionary<string, object>>> ListarCantidadPorTipo();
        Task<decimal> PromedioPoderCombate();
        Task<IEnumerable<string>> ObtenerTipos();
    }
}
