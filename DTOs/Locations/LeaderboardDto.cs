using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Locations
{
    public class LeaderboardDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
