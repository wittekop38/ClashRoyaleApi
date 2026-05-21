using ClashRoyaleApi.DTOs.Common;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Cards
{
    /// <summary>A card as it appears in the global card list from GET /cards.</summary>
    public class CardDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("maxLevel")]
        public int MaxLevel { get; set; }

        [JsonPropertyName("maxEvolutionLevel")]
        public int? MaxEvolutionLevel { get; set; }

        [JsonPropertyName("elixirCost")]
        public int ElixirCost { get; set; }

        /// <summary>Rarity: "common", "rare", "epic", "legendary", or "champion".</summary>
        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonPropertyName("iconUrls")]
        public IconUrlsDto IconUrls { get; set; }
    }
}
