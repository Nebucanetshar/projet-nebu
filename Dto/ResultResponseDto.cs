namespace BlazorApp1.Dto;

public class ResultResponseDto
{
    public string Data { get; set; }
    public double ExecutionTime { get; set; }
    public ResultResponseDto(string json, double duration)
    {
        Data=json;
        ExecutionTime =duration;
    }

}
