using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Cards
{
    /// <summary>
    /// Response from GET /cards. Contains the main card list and the separate support card list.
    /// </summary>
    public class CardsResponseDto
    {
        [JsonPropertyName("items")]
        public List<CardDto> Items { get; set; } = [];

        /// <summary>Support cards (e.g. Mirror, Rage) returned as a separate list.</summary>
        [JsonPropertyName("supportItems")]
        public List<CardDto> SupportItems { get; set; } = [];
    }
}
