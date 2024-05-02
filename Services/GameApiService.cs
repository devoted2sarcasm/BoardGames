using System.Text.Json;
using boardgames.Models.Requests;
// using boardgames.Models.Responses;
// using boardgames.Exceptions;
using boardgames.Models;
using System.Net.Http.Json;

namespace boardgames.Services
{
    public class GameApiService : IGameApiService
    {
        private static readonly string BASE_URL = "http://localhost:5025";

        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<BoardGame>> GetGames() 
        {
            Console.WriteLine("Getting games from API");
            HttpResponseMessage response = await _httpClient.GetAsync($"{BASE_URL}/allGames");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Retrieved games.");
                Console.WriteLine("Response from API: ", responseBody);

                return JsonSerializer.Deserialize<List<BoardGame>>(responseBody);
            }
            else
            {
                Console.WriteLine("Failed to retrieve games.");

                return new List<BoardGame>();
            }
        }

        public async Task<BoardGame> GetGame(int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{BASE_URL}/games/{Id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<BoardGame>(responseBody);
            }
            else
            {
                return new BoardGame();
            }
        }

        public async Task<IEnumerable<BoardGame>> GetAllGames()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BoardGame>>($"{BASE_URL}/allGames");
        }

        public async Task<GamePlayed> GamePlayed(GamePlayed gameplayed)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{BASE_URL}/games/{gameplayed.Game_Id}/play", gameplayed);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<GamePlayed>(responseBody);
            }
            else
            {
                return new GamePlayed();
            }
        }

        public async Task<BoardGame> AddGame(BoardGame game)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{BASE_URL}/games", game);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<BoardGame>(responseBody);
            }
            else
            {
                throw new Exception($"Failed to add game. Status code: {response.StatusCode}");
            }
        }
    }
}