using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Locations
{
    /// <summary>A player's Path of Legend ranking for a location or global season.</summary>
    public class PlayerPathOfLegendRankingDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("expLevel")]
        public int ExpLevel { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        /// <summary>Elo rating used for Path of Legend matchmaking.</summary>
        [JsonPropertyName("eloRating")]
        public int EloRating { get; set; }

        [JsonPropertyName("clan")]
        public PlayerRankingClanDto Clan { get; set; }
    }
}
