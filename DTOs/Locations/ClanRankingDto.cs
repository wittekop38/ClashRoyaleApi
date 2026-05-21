using ClashRoyaleApi.DTOs.Common;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Locations
{
    public class ClanRankingDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("badgeId")]
        public int BadgeId { get; set; }

        [JsonPropertyName("clanScore")]
        public int ClanScore { get; set; }

        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }

        [JsonPropertyName("members")]
        public int Members { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("previousRank")]
        public int PreviousRank { get; set; }
    }
}
