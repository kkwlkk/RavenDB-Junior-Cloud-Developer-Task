using GetTvShowTotalLength.Dto;

namespace GetTvShowTotalLength.Interfaces;

public interface ITvMazeService : IDisposable
{
    public Task<ShowDto?> GetShowAsync(GetShowRequestDto request);
    public Task<int?> GetTotalEpisodeLengthAsync(int showId);
}
