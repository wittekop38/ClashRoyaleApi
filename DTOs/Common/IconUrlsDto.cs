using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Common
{
    public class IconUrlsDto
    {
        [JsonPropertyName("medium")]
        public string Medium { get; set; }

        [JsonPropertyName("small")]
        public string Small { get; set; }

        [JsonPropertyName("large")]
        public string Large { get; set; }
    }
}
