using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon
{
    public class RegistrarPokemonRequest : IRequest<Common.IResult>
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int? PoderCombate { get; set; }
        public DateTime? FechaCaptura { get; set; }
        public IFormFile? Imagen { get; set; }
    }
}
