namespace GetTvShowTotalLength.Dto;

public class GetShowResponseDto
{
    public float Score { get; set; }
    public required ShowDto Show { get; set; }
}
