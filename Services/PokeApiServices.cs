using ActividadAutonoma.Models;
using Newtonsoft.Json;

namespace ActividadAutonoma.Services
{
    public class PokeApiServices
    {
        private readonly HttpClient _httpClient;

        public PokeApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ListaOriginal> GetPokemonListAsync(int offset, int limit)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon?offset={offset}&limit={limit}");
            return JsonConvert.DeserializeObject<ListaOriginal>(response) ?? new ListaOriginal { Results = new List<PokemonSummary>() };
        }

        public async Task<PokemonDetail> GetPokemonDetailAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
                var pokemonDetail = JsonConvert.DeserializeObject<PokemonDetail>(response);

                // Manejar el caso donde la API no devuelve todos los sprites
                if (pokemonDetail != null && pokemonDetail.Sprites != null)
                {
                    // Asegurarse de que OtherSprites esté inicializado
                    pokemonDetail.Sprites.Other ??= new OtherSprites();

                    // Asegurarse de que OfficialArtwork esté inicializado
                    pokemonDetail.Sprites.Other.OfficialArtwork ??= new OfficialArtwork();
                }

                return pokemonDetail ?? new PokemonDetail();
            }
            catch (Exception ex)
            {
                // Log the error (puedes implementar un logger aquí)
                Console.WriteLine($"Error fetching Pokémon details: {ex.Message}");
                return new PokemonDetail();
            }
        }

        public async Task<int> GetTotalPokemonCountAsync()
        {
            var response = await _httpClient.GetStringAsync("https://pokeapi.co/api/v2/pokemon?limit=1");
            var data = JsonConvert.DeserializeObject<dynamic>(response);
            return (int)data.count;
        }
    }
}