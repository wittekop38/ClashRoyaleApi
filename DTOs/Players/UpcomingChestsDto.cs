using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Players
{
    public class UpcomingChestsDto
    {
        [JsonPropertyName("items")]
        public List<UpcomingChestDto> Items { get; set; } = [];
    }

    public class UpcomingChestDto
    {
        /// <summary>Position in the chest cycle from now (0 = next chest).</summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
