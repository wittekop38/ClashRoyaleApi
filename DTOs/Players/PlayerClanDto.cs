using ClashRoyaleApi.DTOs.Common;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Players
{
    /// <summary>Minimal clan info embedded in player and battle responses.</summary>
    public class PlayerClanDto
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
