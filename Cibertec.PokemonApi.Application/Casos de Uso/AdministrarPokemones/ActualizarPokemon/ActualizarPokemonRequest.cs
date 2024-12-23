using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.ActualizarPokemon
{
    public class ActualizarPokemonRequest : IRequest<Common.IResult>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int PoderCombate { get; set; }
        public DateTime FechaCaptura { get; set; }
        public IFormFile? Imagen { get; set; }
    }
}
