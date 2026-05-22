using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Clans
{
    /// <summary>A single entry in the legacy clan war log.</summary>
    public class ClanWarLogEntryDto
    {
        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("createdDate")]
        public string CreatedDate { get; set; }

        [JsonPropertyName("participants")]
        public List<ClanWarParticipantDto> Participants { get; set; } = [];

        [JsonPropertyName("standings")]
        public List<ClanWarStandingDto> Standings { get; set; } = [];
    }
}
