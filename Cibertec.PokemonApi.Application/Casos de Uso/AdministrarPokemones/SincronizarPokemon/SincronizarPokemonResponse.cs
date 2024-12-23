namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.SincronizarPokemon
{
    public class SincronizarPokemonResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int PoderCombate { get; set; }
        public DateTime FechaCaptura { get; set; }
        public string Imagen { get; set; }
    }
}
