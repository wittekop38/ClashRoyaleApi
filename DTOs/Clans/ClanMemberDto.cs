using ClashRoyaleApi.DTOs.Common;
using System.Text.Json.Serialization;

namespace ClashRoyaleApi.DTOs.Clans
{
    public class ClanMemberDto
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>Clan role: "member", "elder", "coLeader", or "leader".</summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>ISO 8601 timestamp of the player's last activity.</summary>
        [JsonPropertyName("lastSeen")]
        public string LastSeen { get; set; }

        [JsonPropertyName("expLevel")]
        public int ExpLevel { get; set; }

        [JsonPropertyName("trophies")]
        public int Trophies { get; set; }

        [JsonPropertyName("arena")]
        public ArenaDto Arena { get; set; }

        [JsonPropertyName("clanRank")]
        public int ClanRank { get; set; }

        [JsonPropertyName("previousClanRank")]
        public int PreviousClanRank { get; set; }

        [JsonPropertyName("donations")]
        public int Donations { get; set; }

        [JsonPropertyName("donationsReceived")]
        public int DonationsReceived { get; set; }

        [JsonPropertyName("clanChestPoints")]
        public int ClanChestPoints { get; set; }
    }
}
