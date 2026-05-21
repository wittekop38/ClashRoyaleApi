using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Players
{
    public class LeagueStatisticsDto
    {
        [JsonPropertyName("currentSeason")]
        public SeasonResultDto CurrentSeason { get; set; }

        [JsonPropertyName("previousSeason")]
        public SeasonResultDto PreviousSeason { get; set; }

        [JsonPropertyName("bestSeason")]
        public SeasonResultDto BestSeason { get; set; }
    }

    public class SeasonResultDto
    {
        /// <summary>Season identifier, e.g. "2023-06". Present on previousSeason and bestSeason.</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("trophies")]
        public int Trophies { get; set; }

        [JsonPropertyName("bestTrophies")]
        public int BestTrophies { get; set; }

        [JsonPropertyName("rank")]
        public int? Rank { get; set; }
    }
}
