# ClashRoyaleApi

A lightweight, fully typed C# wrapper for the [Clash Royale API v1](https://developer.clashroyale.com).

[![NuGet](https://img.shields.io/nuget/v/ClashRoyaleApiLib?color=brightgreen)]([https://www.nuget.org/packages/ClashRoyaleApiLib])

## Installation

```
dotnet add package ClashRoyaleApi
```

## Quick Start

Get an API key from the [Clash Royale Developer Portal](https://developer.clashroyale.com).

```csharp
using ClashRoyaleApi;

var client = new ClashRoyaleClient("your_api_key");

var player = await client.GetPlayerAsync("#2PP");
Console.WriteLine($"{player.Name} — {player.Trophies} trophies");

var clan = await client.GetClanAsync("#2C22YLUR");
Console.WriteLine($"{clan.Name} — {clan.Members}/{clan.MaxMembers} members");
```

Player and clan tags may be passed with or without the leading `#` — both are accepted.

## Dependency Injection / HttpClient Factory

```csharp
// Program.cs
builder.Services.AddHttpClient<ClashRoyaleClient>(client =>
{
    client.BaseAddress = new Uri("https://api.clashroyale.com/v1/");
    client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", "your_api_key");
    client.Timeout = TimeSpan.FromSeconds(30);
});
```

## API Coverage

### Players
| Method | Description |
|---|---|
| `GetPlayerAsync(playerTag)` | Full player profile |
| `GetPlayerBattleLogAsync(playerTag)` | Recent battle log (up to 25 battles) |
| `GetPlayerUpcomingChestsAsync(playerTag)` | Upcoming chest sequence |

### Clans
| Method | Description |
|---|---|
| `SearchClansAsync(name, locationId, ...)` | Search clans by filter criteria |
| `GetClanAsync(clanTag)` | Full clan info including member list |
| `GetClanMembersAsync(clanTag)` | Paginated clan member list |
| `GetClanWarLogAsync(clanTag)` | Legacy war log |
| `GetCurrentRiverRaceAsync(clanTag)` | Current River Race state |
| `GetRiverRaceLogAsync(clanTag)` | River Race history |

### Cards
| Method | Description |
|---|---|
| `GetCardsAsync()` | All cards and support cards |

### Tournaments
| Method | Description |
|---|---|
| `SearchTournamentsAsync(name)` | Search open tournaments |
| `GetTournamentAsync(tournamentTag)` | Tournament details and rankings |
| `GetGlobalTournamentsAsync()` | Current global ladder tournaments |
| `GetGlobalTournamentRankingsAsync(tournamentTag)` | Rankings for a global tournament |

### Events
| Method | Description |
|---|---|
| `GetEventsAsync()` | Current in-game trail events |

### Leaderboards
| Method | Description |
|---|---|
| `GetLeaderboardsAsync()` | All available leaderboards |
| `GetLeaderboardAsync(leaderboardId)` | Specific leaderboard by ID |

### Locations
| Method | Description |
|---|---|
| `GetLocationsAsync()` | All locations/countries |
| `GetLocationAsync(locationId)` | Specific location |
| `GetClanRankingsAsync(locationId)` | Clan trophy rankings by location |
| `GetPlayerRankingsAsync(locationId)` | Player trophy rankings by location |
| `GetClanWarRankingsAsync(locationId)` | Clan war rankings by location |
| `GetLocationPathOfLegendRankingsAsync(locationId)` | Path of Legend rankings by location |

### Seasons
| Method | Description |
|---|---|
| `GetSeasonsAsync()` | All league seasons |
| `GetSeasonsV2Async()` | All league seasons (v2) |
| `GetSeasonAsync(seasonId)` | Specific season (e.g. `"2025-01"`) |
| `GetSeasonPlayerRankingsAsync(seasonId)` | Trophy rankings for a completed season |
| `GetGlobalPathOfLegendRankingsAsync(seasonId)` | Global Path of Legend rankings for a season |

## Pagination

All list endpoints return `PagedResponseDto<T>` with cursor-based pagination:

```csharp
var page1 = await client.GetClanMembersAsync("#2C22YLUR", limit: 10);

if (page1.Paging?.Cursors?.After is string cursor)
{
    var page2 = await client.GetClanMembersAsync("#2C22YLUR", limit: 10, after: cursor);
}
```

## Error Handling

All API errors throw `ClashRoyaleApiException`:

```csharp
try
{
    var player = await client.GetPlayerAsync("#INVALID");
}
catch (ClashRoyaleApiException ex)
{
    Console.WriteLine(ex.StatusCode); // e.g. 404
    Console.WriteLine(ex.Reason);    // e.g. "notFound"
    Console.WriteLine(ex.Message);   // human-readable description
}
```

## License

MIT — see [LICENSE](LICENSE).
