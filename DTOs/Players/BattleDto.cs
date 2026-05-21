using ClashRoyaleApi.DTOs.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Players
{
    public class BattleDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>ISO 8601 timestamp of when the battle took place.</summary>
        [JsonPropertyName("battleTime")]
        public string BattleTime { get; set; }

        [JsonPropertyName("isLadderTournament")]
        public bool IsLadderTournament { get; set; }

        [JsonPropertyName("isHostedMatch")]
        public bool IsHostedMatch { get; set; }

        [JsonPropertyName("arena")]
        public ArenaDto Arena { get; set; }

        [JsonPropertyName("gameMode")]
        public GameModeDto GameMode { get; set; }

        [JsonPropertyName("deckSelection")]
        public string DeckSelection { get; set; }

        [JsonPropertyName("leagueNumber")]
        public int LeagueNumber { get; set; }

        [JsonPropertyName("challengeId")]
        public int? ChallengeId { get; set; }

        [JsonPropertyName("challengeTitle")]
        public string ChallengeTitle { get; set; }

        [JsonPropertyName("challengeWinCountBefore")]
        public int ChallengeWinCountBefore { get; set; }

        [JsonPropertyName("tournamentTag")]
        public string TournamentTag { get; set; }

        [JsonPropertyName("eventTag")]
        public string EventTag { get; set; }

        /// <summary>Indicates which side the player's clan was on in a boat battle.</summary>
        [JsonPropertyName("boatBattleSide")]
        public string BoatBattleSide { get; set; }

        [JsonPropertyName("boatBattleWon")]
        public bool? BoatBattleWon { get; set; }

        [JsonPropertyName("newTowersDestroyed")]
        public int NewTowersDestroyed { get; set; }

        [JsonPropertyName("prevTowersDestroyed")]
        public int PrevTowersDestroyed { get; set; }

        [JsonPropertyName("remainingTowers")]
        public int RemainingTowers { get; set; }

        [JsonPropertyName("modifiers")]
        public List<string> Modifiers { get; set; } = [];

        [JsonPropertyName("team")]
        public List<PlayerBattleDataDto> Team { get; set; } = [];

        [JsonPropertyName("opponent")]
        public List<PlayerBattleDataDto> Opponent { get; set; } = [];
    }

    /// <summary>A participant's data within a battle (formerly BattleParticipantDto).</summary>
    public class PlayerBattleDataDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("startingTrophies")]
        public int StartingTrophies { get; set; }

        [JsonPropertyName("trophyChange")]
        public int TrophyChange { get; set; }

        [JsonPropertyName("crowns")]
        public int Crowns { get; set; }

        [JsonPropertyName("kingTowerHitPoints")]
        public int KingTowerHitPoints { get; set; }

        [JsonPropertyName("princessTowersHitPoints")]
        public List<int> PrincessTowersHitPoints { get; set; }

        [JsonPropertyName("elixirLeaked")]
        public double ElixirLeaked { get; set; }

        [JsonPropertyName("globalRank")]
        public int? GlobalRank { get; set; }

        [JsonPropertyName("clan")]
        public PlayerClanDto Clan { get; set; }

        [JsonPropertyName("cards")]
        public List<PlayerCardDto> Cards { get; set; } = [];

        [JsonPropertyName("supportCards")]
        public List<PlayerCardDto> SupportCards { get; set; } = [];

        /// <summary>Individual rounds for multi-round battles (e.g. best-of-3 challenges).</summary>
        [JsonPropertyName("rounds")]
        public List<PlayerBattleRoundDto> Rounds { get; set; } = [];
    }
}
