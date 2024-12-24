namespace Cibertec.PokemonApi.Domain.PokeApi
{
    public class PokemonDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Imagen { get; set; }
        public decimal PoderCombate { get; set; }
    }
}
