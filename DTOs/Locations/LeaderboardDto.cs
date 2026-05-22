using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Locations
{
    public class LeaderboardDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
