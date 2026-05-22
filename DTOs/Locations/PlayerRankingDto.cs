using ClashRoyaleApiLib.DTOs.Common;
using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Locations
{
    public class PlayerRankingDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("expLevel")]
        public int ExpLevel { get; set; }

        [JsonPropertyName("trophies")]
        public int Trophies { get; set; }

        [JsonPropertyName("arena")]
        public ArenaDto Arena { get; set; }

        [JsonPropertyName("clan")]
        public PlayerRankingClanDto Clan { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("previousRank")]
        public int PreviousRank { get; set; }
    }

    public class PlayerRankingClanDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("badgeId")]
        public int BadgeId { get; set; }

        [JsonPropertyName("badgeUrls")]
        public IconUrlsDto BadgeUrls { get; set; }
    }
}
