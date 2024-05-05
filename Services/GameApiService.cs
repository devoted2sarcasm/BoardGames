using System.Text.Json;
using boardgames.Models.Requests;
// using boardgames.Models.Responses;
// using boardgames.Exceptions;
using boardgames.Models;
using System.Net.Http.Json;
using System.Collections.Generic;
using boardgames.Models.Responses;

namespace boardgames.Services
{
    public class GameApiService : IGameApiService
    {
        private static readonly string BASE_URL = "http://localhost:5025";

        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<BoardGameResponse>> GetGames() 
        {
            Console.WriteLine("Getting games from API");
            HttpResponseMessage response = await _httpClient.GetAsync($"{BASE_URL}/allGames");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Retrieved games.");
                Console.WriteLine("Response from API: ", responseBody);

                return JsonSerializer.Deserialize<List<BoardGameResponse>>(responseBody);
            }
            else
            {
                Console.WriteLine("Failed to retrieve games.");

                return new List<BoardGameResponse>();
            }
        }

        public async Task<BoardGameResponse> GetGame(int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{BASE_URL}/games/{Id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<BoardGameResponse>(responseBody);
            }
            else
            {
                return new BoardGameResponse();
            }
        }

        public async Task<IEnumerable<BoardGameResponse>> GetAllGames()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BoardGameResponse>>($"{BASE_URL}/allGames");
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

        public async Task<BoardGameResponse> AddGame(BoardGame game)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{BASE_URL}/games", game);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<BoardGameResponse>(responseBody);
            }
            else
            {
                throw new Exception($"Failed to add game. Status code: {response.StatusCode}");
            }
        }
    }
}