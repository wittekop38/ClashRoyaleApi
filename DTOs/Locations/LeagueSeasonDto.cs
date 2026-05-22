using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Locations
{
    /// <summary>Identifies a league (trophy road) season.</summary>
    public class LeagueSeasonDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
