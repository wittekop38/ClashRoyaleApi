using ClashRoyaleApiLib.DTOs.Cards;
using ClashRoyaleApiLib.DTOs.Clans;
using ClashRoyaleApiLib.DTOs.Common;
using ClashRoyaleApiLib.DTOs.Events;
using ClashRoyaleApiLib.DTOs.Locations;
using ClashRoyaleApiLib.DTOs.Players;
using ClashRoyaleApiLib.DTOs.Tournaments;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace ClashRoyaleApiLib
{
    /// <summary>
    /// Lightweight wrapper for the Clash Royale API v1.
    /// Authenticates with a static API key issued from the developer portal.
    /// </summary>
    /// <remarks>
    /// Obtain an API key at https://developer.clashroyale.com.
    /// Player and clan tags may be passed with or without the leading '#' — both forms are accepted.
    /// </remarks>
    /// <example>
    /// <code>
    /// var client = new ClashRoyaleClient("your_api_key");
    /// var player = await client.GetPlayerAsync("#2PP");
    /// </code>
    /// </example>
    public class ClashRoyaleClient
    {
        private const string BaseUrl = "https://api.clashroyale.com/v1/";

        private readonly HttpClient _http;

        /// <summary>
        /// Creates a new Clash Royale API client with a dedicated HttpClient.
        /// </summary>
        /// <param name="apiKey">Bearer token from https://developer.clashroyale.com.</param>
        /// <param name="timeoutSeconds">HTTP request timeout in seconds.</param>
        public ClashRoyaleClient(string apiKey, int timeoutSeconds = 30)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl),
                Timeout = TimeSpan.FromSeconds(timeoutSeconds)
            };
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        /// <summary>
        /// Creates a new Clash Royale API client using a pre-configured <see cref="HttpClient"/>.
        /// Useful for testing or when consuming via <c>IHttpClientFactory</c>.
        /// The caller is responsible for setting the <c>Authorization</c> header and base address.
        /// </summary>
        public ClashRoyaleClient(HttpClient httpClient)
        {
            _http = httpClient;
        }

        // ── Players ────────────────────────────────────────────────────────────

        /// <summary>Gets full profile information for a player.</summary>
        /// <param name="playerTag">Player tag (e.g. "#2PP" or "2PP").</param>
        public async Task<PlayerDto> GetPlayerAsync(string playerTag)
            => await GetAsync<PlayerDto>($"players/{FormatTag(playerTag)}");

        /// <summary>Gets a player's recent battle log (up to 25 battles).</summary>
        public async Task<List<BattleDto>> GetPlayerBattleLogAsync(string playerTag)
            => await GetAsync<List<BattleDto>>($"players/{FormatTag(playerTag)}/battlelog") ?? [];

        /// <summary>Gets the list of upcoming chests for a player.</summary>
        public async Task<UpcomingChestsDto> GetPlayerUpcomingChestsAsync(string playerTag)
            => await GetAsync<UpcomingChestsDto>($"players/{FormatTag(playerTag)}/upcomingchests");

        // ── Clans ─────────────────────────────────────────────────────────────

        /// <summary>
        /// Searches for clans by filter criteria. At least one filter (e.g. <paramref name="name"/>) is required by the API.
        /// </summary>
        /// <param name="name">Clan name to search (minimum 3 characters).</param>
        /// <param name="locationId">Filter by location ID.</param>
        /// <param name="minMembers">Minimum member count.</param>
        /// <param name="maxMembers">Maximum member count.</param>
        /// <param name="minScore">Minimum clan score.</param>
        public async Task<PagedResponseDto<ClanSummaryDto>> SearchClansAsync(
            string? name = null, int? locationId = null,
            int? minMembers = null, int? maxMembers = null, int? minScore = null,
            int limit = 30, string? after = null, string? before = null)
        {
            var url = $"clans?limit={limit}";
            if (!string.IsNullOrEmpty(name)) url += $"&name={Uri.EscapeDataString(name)}";
            if (locationId.HasValue) url += $"&locationId={locationId}";
            if (minMembers.HasValue) url += $"&minMembers={minMembers}";
            if (maxMembers.HasValue) url += $"&maxMembers={maxMembers}";
            if (minScore.HasValue) url += $"&minScore={minScore}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<ClanSummaryDto>>(url);
        }

        /// <summary>Gets full information about a specific clan.</summary>
        public async Task<ClanDto> GetClanAsync(string clanTag)
            => await GetAsync<ClanDto>($"clans/{FormatTag(clanTag)}");

        /// <summary>Lists members of a clan.</summary>
        public async Task<PagedResponseDto<ClanMemberDto>> GetClanMembersAsync(
            string clanTag, int limit = 30, string? after = null, string? before = null)
        {
            var url = $"clans/{FormatTag(clanTag)}/members?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<ClanMemberDto>>(url);
        }

        /// <summary>Retrieves the legacy clan war log.</summary>
        public async Task<PagedResponseDto<ClanWarLogEntryDto>> GetClanWarLogAsync(
            string clanTag, int limit = 30, string? after = null, string? before = null)
        {
            var url = $"clans/{FormatTag(clanTag)}/warlog?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<ClanWarLogEntryDto>>(url);
        }

        /// <summary>Retrieves a clan's current legacy clan war state.</summary>
        /// <remarks>
        /// ⚠️ This endpoint has been permanently removed by Supercell (HTTP 410 Gone).
        /// It is kept here for reference only and will always throw <see cref="ClashRoyaleApiException"/> with StatusCode 410.
        /// </remarks>
        [Obsolete("This API endpoint has been permanently removed by Supercell (HTTP 410 Gone).")]
        public async Task<ClanWarDto> GetCurrentClanWarAsync(string clanTag)
            => await GetAsync<ClanWarDto>($"clans/{FormatTag(clanTag)}/currentwar");

        /// <summary>Retrieves a clan's current River Race state.</summary>
        public async Task<RiverRaceDto> GetCurrentRiverRaceAsync(string clanTag)
            => await GetAsync<RiverRaceDto>($"clans/{FormatTag(clanTag)}/currentriverrace");

        /// <summary>Retrieves the River Race log for a clan.</summary>
        public async Task<PagedResponseDto<RiverRaceLogEntryDto>> GetRiverRaceLogAsync(
            string clanTag, int limit = 30, string? after = null, string? before = null)
        {
            var url = $"clans/{FormatTag(clanTag)}/riverracelog?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<RiverRaceLogEntryDto>>(url);
        }

        // ── Cards ─────────────────────────────────────────────────────────────

        /// <summary>
        /// Gets all cards available in the game.
        /// Returns both regular cards (<see cref="CardsResponseDto.Items"/>) and
        /// support cards (<see cref="CardsResponseDto.SupportItems"/>).
        /// </summary>
        public async Task<CardsResponseDto> GetCardsAsync()
            => await GetAsync<CardsResponseDto>("cards");

        // ── Tournaments ───────────────────────────────────────────────────────

        /// <summary>Searches for open tournaments by name (minimum 3 characters).</summary>
        public async Task<PagedResponseDto<TournamentSummaryDto>> SearchTournamentsAsync(
            string name, int limit = 30, string? after = null, string? before = null)
        {
            var url = $"tournaments?name={Uri.EscapeDataString(name)}&limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<TournamentSummaryDto>>(url);
        }

        /// <summary>Gets detailed information about a specific tournament including its member rankings.</summary>
        public async Task<TournamentDto> GetTournamentAsync(string tournamentTag)
            => await GetAsync<TournamentDto>($"tournaments/{FormatTag(tournamentTag)}");

        /// <summary>Gets the list of current global ladder tournaments.</summary>
        public async Task<PagedResponseDto<LadderTournamentDto>> GetGlobalTournamentsAsync()
            => await GetAsync<PagedResponseDto<LadderTournamentDto>>("globaltournaments");

        /// <summary>
        /// Gets rankings for a global ladder tournament.
        /// </summary>
        /// <param name="tournamentTag">Tournament tag (e.g. "#2PP").</param>
        public async Task<PagedResponseDto<LadderTournamentRankingDto>> GetGlobalTournamentRankingsAsync(
            string tournamentTag, int limit = 200, string? after = null, string? before = null)
        {
            var url = $"locations/global/rankings/tournaments/{FormatTag(tournamentTag)}?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<LadderTournamentRankingDto>>(url);
        }

        // ── Events ────────────────────────────────────────────────────────────

        /// <summary>Gets the current list of in-game trail events.</summary>
        public async Task<List<TrailEventDto>> GetEventsAsync()
            => await GetAsync<List<TrailEventDto>>("events") ?? [];

        // ── Leaderboards ──────────────────────────────────────────────────────

        /// <summary>Gets all available leaderboards.</summary>
        public async Task<PagedResponseDto<LeaderboardDto>> GetLeaderboardsAsync()
            => await GetAsync<PagedResponseDto<LeaderboardDto>>("leaderboards");

        /// <summary>Gets a specific leaderboard by ID.</summary>
        public async Task<LeaderboardDto> GetLeaderboardAsync(int leaderboardId)
            => await GetAsync<LeaderboardDto>($"leaderboard/{leaderboardId}");

        // ── Locations ─────────────────────────────────────────────────────────

        /// <summary>Lists all available locations (countries and special regions).</summary>
        public async Task<PagedResponseDto<LocationDto>> GetLocationsAsync(
            int limit = 200, string? after = null, string? before = null)
        {
            var url = $"locations?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<LocationDto>>(url);
        }

        /// <summary>Gets a specific location by ID.</summary>
        public async Task<LocationDto> GetLocationAsync(int locationId)
            => await GetAsync<LocationDto>($"locations/{locationId}");

        /// <summary>Gets clan trophy rankings for a specific location.</summary>
        public async Task<PagedResponseDto<ClanRankingDto>> GetClanRankingsAsync(
            int locationId, int limit = 200, string? after = null, string? before = null)
        {
            var url = $"locations/{locationId}/rankings/clans?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<ClanRankingDto>>(url);
        }

        /// <summary>Gets player trophy rankings for a specific location.</summary>
        public async Task<PagedResponseDto<PlayerRankingDto>> GetPlayerRankingsAsync(
            int locationId, int limit = 200, string? after = null, string? before = null)
        {
            var url = $"locations/{locationId}/rankings/players?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<PlayerRankingDto>>(url);
        }

        /// <summary>Gets clan war trophy rankings for a specific location.</summary>
        public async Task<PagedResponseDto<ClanWarRankingDto>> GetClanWarRankingsAsync(
            int locationId, int limit = 200, string? after = null, string? before = null)
        {
            var url = $"locations/{locationId}/rankings/clanwars?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<ClanWarRankingDto>>(url);
        }

        /// <summary>
        /// Gets current Path of Legend player rankings for a specific location.
        /// </summary>
        public async Task<PagedResponseDto<PlayerPathOfLegendRankingDto>> GetLocationPathOfLegendRankingsAsync(
            int locationId, int limit = 200, string? after = null, string? before = null)
        {
            var url = $"locations/{locationId}/pathoflegend/players?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<PlayerPathOfLegendRankingDto>>(url);
        }

        // ── Seasons ───────────────────────────────────────────────────────────

        /// <summary>Lists all league (trophy road) seasons.</summary>
        public async Task<PagedResponseDto<LeagueSeasonDto>> GetSeasonsAsync()
            => await GetAsync<PagedResponseDto<LeagueSeasonDto>>("locations/global/seasons");

        /// <summary>Lists all league seasons (v2 endpoint).</summary>
        public async Task<PagedResponseDto<LeagueSeasonDto>> GetSeasonsV2Async()
            => await GetAsync<PagedResponseDto<LeagueSeasonDto>>("locations/global/seasonsV2");

        /// <summary>Gets information about a specific league season.</summary>
        /// <param name="seasonId">Season identifier (e.g. "2023-06").</param>
        public async Task<LeagueSeasonDto> GetSeasonAsync(string seasonId)
            => await GetAsync<LeagueSeasonDto>($"locations/global/seasons/{seasonId}");

        /// <summary>Gets global player trophy rankings for a specific league season.</summary>
        /// <param name="seasonId">Season identifier (e.g. "2023-06").</param>
        public async Task<PagedResponseDto<PlayerRankingDto>> GetSeasonPlayerRankingsAsync(
            string seasonId, int limit = 200, string? after = null, string? before = null)
        {
            var url = $"locations/global/seasons/{seasonId}/rankings/players?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<PlayerRankingDto>>(url);
        }

        /// <summary>Gets global Path of Legend player rankings for a specific season.</summary>
        /// <param name="seasonId">Season identifier (e.g. "2023-06").</param>
        public async Task<PagedResponseDto<PlayerPathOfLegendRankingDto>> GetGlobalPathOfLegendRankingsAsync(
            string seasonId, int limit = 200, string? after = null, string? before = null)
        {
            var url = $"locations/global/pathoflegend/{seasonId}/rankings/players?limit={limit}";
            if (!string.IsNullOrEmpty(after)) url += $"&after={after}";
            if (!string.IsNullOrEmpty(before)) url += $"&before={before}";
            return await GetAsync<PagedResponseDto<PlayerPathOfLegendRankingDto>>(url);
        }

        // ── Internals ─────────────────────────────────────────────────────────

        private async Task<T> GetAsync<T>(string url)
        {
            var response = await _http.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));

            if (!response.IsSuccessStatusCode)
            {
                string reason = "", message = "";
                try
                {
                    var error = await response.Content.ReadFromJsonAsync<JsonElement>();
                    if (error.TryGetProperty("reason", out var r)) reason = r.GetString() ?? "";
                    if (error.TryGetProperty("message", out var m)) message = m.GetString() ?? "";
                }
                catch { }
                throw new ClashRoyaleApiException((int)response.StatusCode, reason, message);
            }

            return (await response.Content.ReadFromJsonAsync<T>())!;
        }

        /// <summary>
        /// URL-encodes a Clash Royale tag, converting the leading '#' to '%23'.
        /// Both "#2PP" and "2PP" are accepted.
        /// </summary>
        public static string FormatTag(string tag)
            => Uri.EscapeDataString(tag.StartsWith('#') ? tag : '#' + tag);
    }
}
