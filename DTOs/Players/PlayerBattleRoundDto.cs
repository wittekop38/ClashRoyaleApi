using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Players
{
    /// <summary>A single round within a multi-round battle (e.g. best-of-3 challenges).</summary>
    public class PlayerBattleRoundDto
    {
        [JsonPropertyName("crowns")]
        public int Crowns { get; set; }

        [JsonPropertyName("kingTowerHitPoints")]
        public int KingTowerHitPoints { get; set; }

        [JsonPropertyName("princessTowersHitPoints")]
        public List<int> PrincessTowersHitPoints { get; set; }

        [JsonPropertyName("elixirLeaked")]
        public double ElixirLeaked { get; set; }

        [JsonPropertyName("cards")]
        public List<PlayerCardDto> Cards { get; set; } = [];
    }
}
