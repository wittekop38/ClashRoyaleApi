using ClashRoyaleApiLib.DTOs.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Players
{
    public class PlayerDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("expLevel")]
        public int ExpLevel { get; set; }

        [JsonPropertyName("expPoints")]
        public int ExpPoints { get; set; }

        [JsonPropertyName("totalExpPoints")]
        public int TotalExpPoints { get; set; }

        [JsonPropertyName("trophies")]
        public int Trophies { get; set; }

        [JsonPropertyName("bestTrophies")]
        public int BestTrophies { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("battleCount")]
        public int BattleCount { get; set; }

        [JsonPropertyName("threeCrownWins")]
        public int ThreeCrownWins { get; set; }

        [JsonPropertyName("challengeCardsWon")]
        public int ChallengeCardsWon { get; set; }

        [JsonPropertyName("challengeMaxWins")]
        public int ChallengeMaxWins { get; set; }

        [JsonPropertyName("tournamentCardsWon")]
        public int TournamentCardsWon { get; set; }

        [JsonPropertyName("tournamentBattleCount")]
        public int TournamentBattleCount { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("donations")]
        public int Donations { get; set; }

        [JsonPropertyName("donationsReceived")]
        public int DonationsReceived { get; set; }

        [JsonPropertyName("totalDonations")]
        public int TotalDonations { get; set; }

        [JsonPropertyName("warDayWins")]
        public int WarDayWins { get; set; }

        [JsonPropertyName("clanCardsCollected")]
        public int ClanCardsCollected { get; set; }

        [JsonPropertyName("starPoints")]
        public int StarPoints { get; set; }

        [JsonPropertyName("legacyTrophyRoadHighScore")]
        public int LegacyTrophyRoadHighScore { get; set; }

        [JsonPropertyName("currentWinLoseStreak")]
        public int CurrentWinLoseStreak { get; set; }

        [JsonPropertyName("arena")]
        public ArenaDto Arena { get; set; }

        [JsonPropertyName("clan")]
        public PlayerClanDto Clan { get; set; }

        [JsonPropertyName("leagueStatistics")]
        public LeagueStatisticsDto LeagueStatistics { get; set; }

        /// <summary>Current Path of Legend season result.</summary>
        [JsonPropertyName("currentPathOfLegendSeasonResult")]
        public PathOfLegendSeasonResultDto CurrentPathOfLegendSeasonResult { get; set; }

        /// <summary>Last completed Path of Legend season result.</summary>
        [JsonPropertyName("lastPathOfLegendSeasonResult")]
        public PathOfLegendSeasonResultDto LastPathOfLegendSeasonResult { get; set; }

        /// <summary>Best Path of Legend season result ever achieved.</summary>
        [JsonPropertyName("bestPathOfLegendSeasonResult")]
        public PathOfLegendSeasonResultDto BestPathOfLegendSeasonResult { get; set; }

        [JsonPropertyName("badges")]
        public List<PlayerBadgeDto> Badges { get; set; } = [];

        [JsonPropertyName("achievements")]
        public List<AchievementDto> Achievements { get; set; } = [];

        [JsonPropertyName("cards")]
        public List<PlayerCardDto> Cards { get; set; } = [];

        /// <summary>Support cards in the player's collection.</summary>
        [JsonPropertyName("supportCards")]
        public List<PlayerCardDto> SupportCards { get; set; } = [];

        [JsonPropertyName("currentDeck")]
        public List<PlayerCardDto> CurrentDeck { get; set; } = [];

        /// <summary>Support cards currently in the player's deck.</summary>
        [JsonPropertyName("currentDeckSupportCards")]
        public List<PlayerCardDto> CurrentDeckSupportCards { get; set; } = [];

        [JsonPropertyName("currentFavouriteCard")]
        public PlayerCardDto CurrentFavouriteCard { get; set; }
    }
}
