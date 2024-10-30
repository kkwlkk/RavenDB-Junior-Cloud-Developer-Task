using GetTvShowTotalLength.Handlers;
using GetTvShowTotalLength.Interfaces;
using GetTvShowTotalLength.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GetTvShowTotalLength;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var serviceProvider = ConfigureServices();
        var handler = serviceProvider.GetRequiredService<TvShowLengthHandler>();
        
        var totalLength = await handler.HandleInputAndGetShowTotalEpisodesLength(args);
        Console.WriteLine(totalLength);
        Environment.Exit(0);
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection()
            .AddSingleton<ITvMazeService, TvMazeService>()
            .AddSingleton<TvShowLengthHandler>();

        return services.BuildServiceProvider();
    }
}
