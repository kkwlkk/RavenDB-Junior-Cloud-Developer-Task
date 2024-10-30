using GetTvShowTotalLength.Dto;
using GetTvShowTotalLength.Interfaces;

namespace GetTvShowTotalLength.Handlers;

public class TvShowLengthHandler
{
    private readonly ITvMazeService _tvMazeService;

    public TvShowLengthHandler(ITvMazeService tvMazeService)
    {
        _tvMazeService = tvMazeService;
    }

    public async Task<int?> HandleInputAndGetShowTotalEpisodesLength(string[] args)
    {
        var input = await ReadInput(args);

        if (string.IsNullOrWhiteSpace(input))
        {
            Environment.Exit(1);
        }

        var data = await _tvMazeService.GetShowAsync(new GetShowRequestDto { ShowName = input });

        if (data?.Id == null)
        {
            Environment.Exit(10);
        }

        var totalShowLength = await _tvMazeService.GetTotalEpisodeLengthAsync(data.Id.Value);

        if (!totalShowLength.HasValue)
        {
            Environment.Exit(10);
        }

        return totalShowLength;
    }

    private static async Task<string> ReadInput(string[] args)
    {
        if (args.Length > 0)
        {
            return string.Join(" ", args);
        }

        try
        {
            return await Console.In.ReadToEndAsync();
        }
        catch
        {
            Environment.Exit(1);
            return string.Empty;
        }
    }
}
