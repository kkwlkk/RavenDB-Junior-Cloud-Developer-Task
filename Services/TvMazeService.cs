using GetTvShowTotalLength.Dto;
using GetTvShowTotalLength.Interfaces;
using System.Net.Http.Json;

namespace GetTvShowTotalLength.Services;

public sealed class TvMazeService : ITvMazeService
{
    private readonly HttpClient _httpClient;

    public TvMazeService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.tvmaze.com");
    }

    public async Task<ShowDto?> GetShowAsync(GetShowRequestDto request)
    {
        try
        {
            var shows = await _httpClient.GetFromJsonAsync<GetShowResponseDto[]>($"/search/shows?q={request.ShowName}");

            if (shows is null || shows.Length == 0)
            {
                return null;
            }

            var mostRecentShow = shows
                .Select(show => show.Show)
                .MaxBy(show => show.Premiered);

            return mostRecentShow ?? null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<int?> GetTotalEpisodeLengthAsync(int showId)
    {
        try
        {
            var episodesList = await _httpClient.GetFromJsonAsync<GetEpisodesListResponseDto>($"/shows/{showId}/episodes");

            if (episodesList is null || episodesList.Count == 0)
            {
                return null;
            }

            var totalLength = episodesList.Sum(episode => episode.Runtime);
            return totalLength;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public void Dispose() => _httpClient.Dispose();
}
