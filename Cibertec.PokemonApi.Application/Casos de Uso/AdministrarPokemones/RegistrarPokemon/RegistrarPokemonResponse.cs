namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon
{
    public class RegistrarPokemonResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int PoderCombate { get; set; }
        public DateTime FechaCaptura { get; set; }
        public string Imagen { get; set; }

        public string ImagenUrl => $"{BaseUrl}{Imagen}";

        private static string BaseUrl = ""; // Se configurará dinámicamente

        // Método para establecer el dominio base
        public static void SetBaseUrl(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
    }
}
