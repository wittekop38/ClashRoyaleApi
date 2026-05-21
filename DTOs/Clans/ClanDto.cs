using ClashRoyaleApi.DTOs.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Clans
{
    /// <summary>Full clan profile returned by GET /clans/{clanTag}.</summary>
    public class ClanDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>Clan type: "open", "inviteOnly", or "closed".</summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("badgeId")]
        public int BadgeId { get; set; }

        [JsonPropertyName("clanScore")]
        public int ClanScore { get; set; }

        [JsonPropertyName("clanWarTrophies")]
        public int ClanWarTrophies { get; set; }

        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }

        [JsonPropertyName("requiredTrophies")]
        public int RequiredTrophies { get; set; }

        [JsonPropertyName("donationsPerWeek")]
        public int DonationsPerWeek { get; set; }

        [JsonPropertyName("clanChestStatus")]
        public string ClanChestStatus { get; set; }

        [JsonPropertyName("clanChestLevel")]
        public int ClanChestLevel { get; set; }

        [JsonPropertyName("clanChestMaxLevel")]
        public int ClanChestMaxLevel { get; set; }

        [JsonPropertyName("clanChestPoints")]
        public int ClanChestPoints { get; set; }

        /// <summary>Current member count.</summary>
        [JsonPropertyName("members")]
        public int Members { get; set; }

        [JsonPropertyName("memberList")]
        public List<ClanMemberDto> MemberList { get; set; } = [];
    }

    /// <summary>Reduced clan data returned by clan search results.</summary>
    public class ClanSummaryDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("badgeId")]
        public int BadgeId { get; set; }

        [JsonPropertyName("clanScore")]
        public int ClanScore { get; set; }

        [JsonPropertyName("clanWarTrophies")]
        public int ClanWarTrophies { get; set; }

        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }

        [JsonPropertyName("members")]
        public int Members { get; set; }

        [JsonPropertyName("requiredTrophies")]
        public int RequiredTrophies { get; set; }

        [JsonPropertyName("donationsPerWeek")]
        public int DonationsPerWeek { get; set; }
    }
}
