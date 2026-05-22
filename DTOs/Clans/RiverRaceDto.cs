using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Clans
{
    /// <summary>Current River Race state returned by GET /clans/{clanTag}/currentriverrace.</summary>
    public class RiverRaceDto
    {
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("periodType")]
        public string PeriodType { get; set; }

        [JsonPropertyName("periodIndex")]
        public int PeriodIndex { get; set; }

        [JsonPropertyName("sectionIndex")]
        public int SectionIndex { get; set; }

        [JsonPropertyName("warEndTime")]
        public string WarEndTime { get; set; }

        [JsonPropertyName("collectionEndTime")]
        public string CollectionEndTime { get; set; }

        /// <summary>The requesting clan's detailed data within the race.</summary>
        [JsonPropertyName("clan")]
        public RiverRaceClanDto Clan { get; set; }

        /// <summary>All clans in this River Race (5 total including own clan).</summary>
        [JsonPropertyName("clans")]
        public List<RiverRaceClanDto> Clans { get; set; } = [];

        /// <summary>Day-by-day period logs tracking fame progress throughout the race.</summary>
        [JsonPropertyName("periodLogs")]
        public List<PeriodLogDto> PeriodLogs { get; set; } = [];
    }

    public class PeriodLogDto
    {
        [JsonPropertyName("periodIndex")]
        public int PeriodIndex { get; set; }

        [JsonPropertyName("items")]
        public List<PeriodLogEntryDto> Items { get; set; } = [];
    }

    public class PeriodLogEntryDto
    {
        [JsonPropertyName("clan")]
        public PeriodLogEntryClanDto Clan { get; set; }

        [JsonPropertyName("pointsEarned")]
        public int PointsEarned { get; set; }

        [JsonPropertyName("progressStartOfDay")]
        public int ProgressStartOfDay { get; set; }

        [JsonPropertyName("progressEndOfDay")]
        public int ProgressEndOfDay { get; set; }

        [JsonPropertyName("endOfDayRank")]
        public int EndOfDayRank { get; set; }

        [JsonPropertyName("progressEarned")]
        public int ProgressEarned { get; set; }

        [JsonPropertyName("numOfDefensesRemaining")]
        public int NumOfDefensesRemaining { get; set; }

        [JsonPropertyName("progressEarnedFromDefenses")]
        public int ProgressEarnedFromDefenses { get; set; }
    }

    public class PeriodLogEntryClanDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }

    public class RiverRaceClanDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("badgeId")]
        public int BadgeId { get; set; }

        [JsonPropertyName("fame")]
        public int Fame { get; set; }

        [JsonPropertyName("repairPoints")]
        public int RepairPoints { get; set; }

        [JsonPropertyName("finishTime")]
        public string FinishTime { get; set; }

        [JsonPropertyName("periodPoints")]
        public int PeriodPoints { get; set; }

        [JsonPropertyName("clanScore")]
        public int ClanScore { get; set; }

        [JsonPropertyName("trophyChange")]
        public int TrophyChange { get; set; }

        [JsonPropertyName("participants")]
        public List<RiverRaceParticipantDto> Participants { get; set; } = [];
    }

    public class RiverRaceParticipantDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("fame")]
        public int Fame { get; set; }

        [JsonPropertyName("repairPoints")]
        public int RepairPoints { get; set; }

        [JsonPropertyName("boatAttacks")]
        public int BoatAttacks { get; set; }

        [JsonPropertyName("decksUsed")]
        public int DecksUsed { get; set; }

        [JsonPropertyName("decksUsedToday")]
        public int DecksUsedToday { get; set; }

        [JsonPropertyName("medals")]
        public int Medals { get; set; }
    }
}
