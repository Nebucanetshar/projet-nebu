using BlazorApp1.Dto;
namespace BlazorApp1.ViewModel;

public enum MessageTypeViewModel
{
    Debug = 0,
    Info = 1,
    Warning = 2,
    Error = 3,
    CriticalError = 4
}

public class ResultMessageViewModel
{
    #region Attributes & Accessors
    public DateTime DateTime { get; }
    public string Label { get; }
    public MessageTypeViewModel Type { get; }
    #endregion

    #region Constructors
    public ResultMessageViewModel(MessageTypeViewModel key, ResultMessageDto dto)
        : this(dto.Message)
    {
    }

    public ResultMessageViewModel(string label, MessageTypeViewModel type = MessageTypeViewModel.Info)
    {
        DateTime = DateTime.Now;
        Label = label;
        Type = type;
    }

   
    #endregion

    #region Methods
    #endregion
}