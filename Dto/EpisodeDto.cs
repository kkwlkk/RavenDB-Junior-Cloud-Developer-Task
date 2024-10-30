using Newtonsoft.Json;

namespace GetTvShowTotalLength.Dto;

public class EpisodeDto
{
    public string? Airdate { get; set; }
    public string? Airstamp { get; set; }
    public string? Airtime { get; set; }
    public int? Id { get; set; }
    public ImageDto? Image { get; set; }
    public string? Name { get; set; }
    public int? Number { get; set; }
    public RatingDto? Rating { get; set; }
    public int? Runtime { get; set; }
    public int? Season { get; set; }
    public string? Summary { get; set; }
    public string? Type { get; set; }
    public string? Url { get; set; }
    [JsonProperty("_links")]
    public LinksDto? Links { get; set; }
    
    public sealed class ImageDto
    {
        public string? Medium { get; set; }
        public string? Original { get; set; }
    }
    
    public sealed class RatingDto
    {
        public double? Average { get; set; }
    }
    
    public sealed class LinksDto
    {
        public LinkDto? Self { get; set; }
        public LinkDto? Show { get; set; }
    }
    
    public sealed class LinkDto 
    {
        public string? Href { get; set; }
        public string? Name { get; set; }
    }
}
