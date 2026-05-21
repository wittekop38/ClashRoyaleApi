using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Clans
{
    /// <summary>A single finished River Race in the log.</summary>
    public class RiverRaceLogEntryDto
    {
        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("sectionIndex")]
        public int SectionIndex { get; set; }

        [JsonPropertyName("createdDate")]
        public string CreatedDate { get; set; }

        [JsonPropertyName("standings")]
        public List<RiverRaceLogStandingDto> Standings { get; set; } = [];
    }

    public class RiverRaceLogStandingDto
    {
        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("trophyChange")]
        public int TrophyChange { get; set; }

        [JsonPropertyName("clan")]
        public RiverRaceClanDto Clan { get; set; }
    }
}
