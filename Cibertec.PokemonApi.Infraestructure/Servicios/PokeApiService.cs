using Cibertec.PokemonApi.Domain.PokeApi;
using Cibertec.PokemonApi.Domain.Servicios;
using System.Text.Json;

namespace Cibertec.PokemonApi.Infraestructure.Servicios
{
    public class PokeApiService : IPokeApiService
    {
        private readonly HttpClient _httpClient;

        public PokeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        public async Task<List<PokemonResult>> GetPokemonListAsync(int limit = 20, int offset = 0)
        {
            var response = await _httpClient.GetAsync($"pokemon?limit={limit}&offset={offset}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PokemonListResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result.Results
                 .Select(p => new PokemonResult
                 {
                     Name = p.Name,
                     Url = p.Url
                 })
                 .ToList();
        }

        public async Task<PokemonDetail> GetPokemonByNameAsync(string name)
        {
            var response = await _httpClient.GetAsync($"pokemon/{name}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var tempObject = JsonSerializer.Deserialize<JsonElement>(content);

            // Extraer los valores
            var id = tempObject.GetProperty("id").GetInt32();
            var nombre = tempObject.GetProperty("name").GetString();
            var typesArray = tempObject.GetProperty("types").EnumerateArray();
            string? tipo = typesArray.FirstOrDefault().GetProperty("type").GetProperty("name").GetString();
            var imagen = tempObject.GetProperty("sprites").GetProperty("front_default").GetString();

            var statsArray = tempObject.GetProperty("stats").EnumerateArray().Select(stat => stat.GetProperty("base_stat").GetInt32());

            var poderCombate = statsArray.Any() ? statsArray.Average() : 0;

            var pokemonDetail = new PokemonDetail
            {
                Id = id,
                Name = nombre,
                Type = tipo,
                Imagen = imagen,
                PoderCombate = (decimal)poderCombate
            };

            return pokemonDetail;
        }

        public async Task<string> DescargarYGuardarImagen(string url, string name)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("No se pudo descargar la imagen.");
                }

                var uploadsFolder = Path.Combine("wwwroot", "images", "pokemons");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var extension = Path.GetExtension(url);
                var fileName = $"{Guid.NewGuid()}_{name.ToLower()}{extension}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await response.Content.CopyToAsync(fileStream);
                }

                return $"/images/pokemons/{fileName}";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la imagen.", ex);
            }
        }
    }
}
