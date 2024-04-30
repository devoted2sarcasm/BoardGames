using System.Text.Json.Serialization;

namespace boardgames.Models.Requests
{
    public class BoardGameRequest
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("minPlayers")]
        public int MinPlayers { get; set; }

        [JsonPropertyName("maxPlayers")]
        public int MaxPlayers { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("difficulty")]
        public int? Difficulty { get; set; }

        [JsonPropertyName("rank")]
        public int? Rank { get; set; }

        [JsonPropertyName("idealPlayerCount")]
        public int? IdealPlayerCount { get; set; }

        [JsonPropertyName("playtime")]
        public int? Playtime { get; set; }
        
        
    }
}