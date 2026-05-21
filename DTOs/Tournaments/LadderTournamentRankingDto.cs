using ClashRoyaleApi.DTOs.Locations;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Tournaments
{
    /// <summary>A player's ranking in a global ladder tournament.</summary>
    public class LadderTournamentRankingDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("previousRank")]
        public int PreviousRank { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("clan")]
        public PlayerRankingClanDto Clan { get; set; }
    }
}
