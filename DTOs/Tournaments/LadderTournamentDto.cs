using ClashRoyaleApiLib.DTOs.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Tournaments
{
    /// <summary>A global ladder tournament returned by GET /globaltournaments.</summary>
    public class LadderTournamentDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("startTime")]
        public string StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public string EndTime { get; set; }

        [JsonPropertyName("gameMode")]
        public GameModeDto GameMode { get; set; }

        [JsonPropertyName("minExpLevel")]
        public int MinExpLevel { get; set; }

        [JsonPropertyName("tournamentLevel")]
        public int TournamentLevel { get; set; }

        [JsonPropertyName("maxLosses")]
        public int MaxLosses { get; set; }

        [JsonPropertyName("maxTopRewardRank")]
        public int MaxTopRewardRank { get; set; }

        [JsonPropertyName("milestoneRewards")]
        public List<SurvivalMilestoneRewardDto> MilestoneRewards { get; set; } = [];

        [JsonPropertyName("freeTierRewards")]
        public List<SurvivalMilestoneRewardDto> FreeTierRewards { get; set; } = [];

        [JsonPropertyName("topRankReward")]
        public List<SurvivalMilestoneRewardDto> TopRankReward { get; set; } = [];
    }

    public class SurvivalMilestoneRewardDto
    {
        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonPropertyName("chest")]
        public string Chest { get; set; }

        [JsonPropertyName("resource")]
        public string Resource { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("consumableName")]
        public string ConsumableName { get; set; }
    }
}
