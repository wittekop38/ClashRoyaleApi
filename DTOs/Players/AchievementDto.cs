using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Players
{
    public class AchievementDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("stars")]
        public int Stars { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("target")]
        public int Target { get; set; }

        [JsonPropertyName("info")]
        public string Info { get; set; }

        [JsonPropertyName("completionInfo")]
        public string CompletionInfo { get; set; }
    }
}
