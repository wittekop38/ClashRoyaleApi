using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Common
{
    public class ArenaDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("iconUrls")]
        public IconUrlsDto IconUrls { get; set; }

        [JsonPropertyName("rawName")]
        public string RawName { get; set; }

        [JsonPropertyName("trophyLimit")]
        public int TrophyLimit { get; set; }
    }
}
