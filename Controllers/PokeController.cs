using ActividadAutonoma.Services;
using ActividadAutonoma.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ActividadAutonoma.Controllers
{
    public class PokeController : Controller
    {
        private readonly PokeApiServices _pokeApiService;
        private readonly HttpClient _httpClient;
        private const int PageSize = 20;

        public PokeController(PokeApiServices pokeApiService, HttpClient httpClient)
        {
            _pokeApiService = pokeApiService;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(int page = 62) // Página 62 por defecto
        {
            ViewData["Page"] = page;

            // Obtener el conteo total de Pokémon
            int totalCount = await GetTotalPokemonCount();
            ViewData["TotalPages"] = (int)Math.Ceiling(totalCount / (double)PageSize);

            int offset = (page - 1) * PageSize;
            var lista = await _pokeApiService.GetPokemonListAsync(offset, PageSize);

            if (lista == null)
            {
                return Content("¡Lista es null! Revisa deserialización o HttpClient.");
            }

            return View(lista);
        }

        private async Task<int> GetTotalPokemonCount()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://pokeapi.co/api/v2/pokemon?limit=1");
                var data = JsonConvert.DeserializeObject<dynamic>(response);
                return (int)data.count;
            }
            catch
            {
                return 1300; // Valor por defecto aproximado
            }
        }

        public async Task<IActionResult> Detalles(int id)
        {
            var detalle = await _pokeApiService.GetPokemonDetailAsync(id);

            if (detalle == null || detalle.Id == 0)
            {
                return NotFound(); // Manejar Pokémon no encontrado
            }

            return View(detalle);
        }
    }
}