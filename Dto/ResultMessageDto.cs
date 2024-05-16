using BlazorApp1.ViewModel;

namespace BlazorApp1.Dto;

public class ResultMessageDto
{
    public MessageTypeViewModel Type { get; set; }
    public string Message { get; set; }

    public void ToMessageTypeViewModel()
    {
        
    }

}
