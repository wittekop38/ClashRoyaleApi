using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Clans
{
    /// <summary>Current legacy clan war state returned by GET /clans/{clanTag}/currentwar.</summary>
    public class ClanWarDto
    {
        /// <summary>War state: "notInWar", "collectionDay", "warDay", "ended".</summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("warEndTime")]
        public string WarEndTime { get; set; }

        [JsonPropertyName("clan")]
        public ClanWarClanDto Clan { get; set; }

        [JsonPropertyName("participants")]
        public List<ClanWarParticipantDto> Participants { get; set; } = [];

        [JsonPropertyName("standings")]
        public List<ClanWarStandingDto> Standings { get; set; } = [];
    }

    public class ClanWarClanDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("badgeId")]
        public int BadgeId { get; set; }

        [JsonPropertyName("clanScore")]
        public int ClanScore { get; set; }

        [JsonPropertyName("participants")]
        public int Participants { get; set; }

        [JsonPropertyName("battlesPlayed")]
        public int BattlesPlayed { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("crownsEarned")]
        public int CrownsEarned { get; set; }
    }

    public class ClanWarParticipantDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cardsEarned")]
        public int CardsEarned { get; set; }

        [JsonPropertyName("battlesPlayed")]
        public int BattlesPlayed { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("collectionDayBattlesPlayed")]
        public int CollectionDayBattlesPlayed { get; set; }

        [JsonPropertyName("numberOfBattles")]
        public int NumberOfBattles { get; set; }
    }

    public class ClanWarStandingDto
    {
        [JsonPropertyName("clan")]
        public ClanWarClanDto Clan { get; set; }

        [JsonPropertyName("trophyChange")]
        public int TrophyChange { get; set; }
    }
}
