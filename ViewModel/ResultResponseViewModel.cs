using BlazorApp1.Dto;
namespace BlazorApp1.ViewModel;

public class ResultResponseViewModel: ViewModelBase
{
    public string Data {get;set;}
    public double ExecutionTime {get;set;}

    public ResultResponseViewModel()
    {
        ExecutionTime = -1;
        Data=string.Empty;
    }

    public ResultResponseViewModel(ResultResponseDto dto)
    {
        Data = dto.Data;
        ExecutionTime = dto.ExecutionTime;
    }
}
