using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Events
{
    public class TrailEventDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("eventTag")]
        public string EventTag { get; set; }
    }
}
