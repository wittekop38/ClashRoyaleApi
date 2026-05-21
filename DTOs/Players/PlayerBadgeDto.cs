using ClashRoyaleApi.DTOs.Common;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Players
{
    public class PlayerBadgeDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("progress")]
        public int Progress { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("maxLevel")]
        public int MaxLevel { get; set; }

        [JsonPropertyName("target")]
        public int Target { get; set; }

        [JsonPropertyName("iconUrls")]
        public IconUrlsDto IconUrls { get; set; }
    }
}
