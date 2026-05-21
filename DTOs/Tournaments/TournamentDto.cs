using ClashRoyaleApi.DTOs.Common;
using ClashRoyaleApi.DTOs.Players;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Tournaments
{
    /// <summary>Full tournament data returned by GET /tournaments/{tournamentTag}.</summary>
    public class TournamentDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("creatorTag")]
        public string CreatorTag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("gameMode")]
        public GameModeDto GameMode { get; set; }

        [JsonPropertyName("preparationDuration")]
        public int PreparationDuration { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }

        [JsonPropertyName("maxCapacity")]
        public int MaxCapacity { get; set; }

        [JsonPropertyName("levelCap")]
        public int LevelCap { get; set; }

        [JsonPropertyName("firstPlaceCardPrize")]
        public int? FirstPlaceCardPrize { get; set; }

        [JsonPropertyName("members")]
        public List<TournamentMemberDto> Members { get; set; } = [];
    }

    /// <summary>Reduced tournament data returned by tournament search results.</summary>
    public class TournamentSummaryDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }

        [JsonPropertyName("maxCapacity")]
        public int MaxCapacity { get; set; }

        [JsonPropertyName("preparationDuration")]
        public int PreparationDuration { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("gameMode")]
        public GameModeDto GameMode { get; set; }

        [JsonPropertyName("levelCap")]
        public int LevelCap { get; set; }
    }

    public class TournamentMemberDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("clan")]
        public PlayerClanDto Clan { get; set; }
    }
}
