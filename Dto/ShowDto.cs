namespace GetTvShowTotalLength.Dto;

public class ShowDto
{
    public int? Id { get; set; }
    public string? Url { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Language { get; set; }
    public List<string>? Genres { get; set; }
    public string? Status { get; set; }
    public int? Runtime { get; set; }
    public int? AverageRuntime { get; set; }
    public DateTime? Premiered { get; set; }
    public DateTime? Ended { get; set; }
    public string? OfficialSite { get; set; }
    public ScheduleDto? Schedule { get; set; }
    public RatingDto? Rating { get; set; }
    public int? Weight { get; set; }
    public NetworkDto? Network { get; set; }
    public object? WebChannel { get; set; }
    public object? DvdCountry { get; set; }
    public ExternalsDto? Externals { get; set; }
    public ImageDto? Image { get; set; }
    public string? Summary { get; set; }
    public long? Updated { get; set; }
    public LinksDto? Links { get; set; }

    public sealed class ScheduleDto
    {
        public string? Time { get; set; }
        public List<string>? Days { get; set; }
    }
    
    public sealed class RatingDto
    {
        public double? Average { get; set; }
    }
    
    public sealed class NetworkDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public CountryDto? Country { get; set; }
        public string? OfficialSite { get; set; }
    }
    
    public sealed class CountryDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Timezone { get; set; }
    }
    
    public sealed class ExternalsDto
    {
        public int? Tvrage { get; set; }
        public int? Thetvdb { get; set; }
        public string? Imdb { get; set; }
    }
    
    public sealed class ImageDto
    {
        public string? Medium { get; set; }
        public string? Original { get; set; }
    }
    
    public sealed class LinksDto
    {
        public Link? Self { get; set; }
        public Link? PreviousEpisode { get; set; }
    }
    
    public sealed class Link
    {
        public string? Href { get; set; }
        public string? Name { get; set; }
    }
}
