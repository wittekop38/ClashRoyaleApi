using ClashRoyaleApiLib.DTOs.Common;
using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Players
{
    /// <summary>A card as it appears in a player's collection or current deck.</summary>
    public class PlayerCardDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("starLevel")]
        public int StarLevel { get; set; }

        [JsonPropertyName("maxLevel")]
        public int MaxLevel { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonPropertyName("elixirCost")]
        public int ElixirCost { get; set; }

        [JsonPropertyName("evolutionLevel")]
        public int? EvolutionLevel { get; set; }

        [JsonPropertyName("maxEvolutionLevel")]
        public int? MaxEvolutionLevel { get; set; }

        [JsonPropertyName("iconUrls")]
        public IconUrlsDto IconUrls { get; set; }
    }
}
