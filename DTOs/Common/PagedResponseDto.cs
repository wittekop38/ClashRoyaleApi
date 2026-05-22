using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClashRoyaleApiLib.DTOs.Common
{
    /// <summary>
    /// Wraps a paginated API response. Use <see cref="Paging"/> to retrieve cursor values
    /// for requesting the next or previous page.
    /// </summary>
    public class PagedResponseDto<T>
    {
        [JsonPropertyName("items")]
        public List<T> Items { get; set; } = [];

        [JsonPropertyName("paging")]
        public PagingDto Paging { get; set; }
    }

    public class PagingDto
    {
        [JsonPropertyName("cursors")]
        public PagingCursorsDto Cursors { get; set; }
    }

    public class PagingCursorsDto
    {
        /// <summary>Pass to the <c>before</c> parameter to fetch the previous page.</summary>
        [JsonPropertyName("before")]
        public string Before { get; set; }

        /// <summary>Pass to the <c>after</c> parameter to fetch the next page.</summary>
        [JsonPropertyName("after")]
        public string After { get; set; }
    }
}
