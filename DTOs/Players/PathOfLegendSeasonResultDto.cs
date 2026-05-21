using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Players
{
    /// <summary>A player's Path of Legend result for a specific season.</summary>
    public class PathOfLegendSeasonResultDto
    {
        [JsonPropertyName("trophies")]
        public int Trophies { get; set; }

        [JsonPropertyName("rank")]
        public int? Rank { get; set; }

        [JsonPropertyName("leagueNumber")]
        public int LeagueNumber { get; set; }
    }
}
