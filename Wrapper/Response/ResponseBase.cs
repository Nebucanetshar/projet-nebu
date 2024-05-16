using BlazorApp1.Dto;
namespace BlazorApp1.Wrapper.Response;
public interface IResponseBase
{
    IEnumerable<ResultMessageDto> Messages { get; }

    object? Result { get; }
}

public abstract class ResponseBase : IResponseBase
{

    #region Attributes & Accessors
    public abstract IEnumerable<ResultMessageDto> Messages { get; }

    public virtual object? Result => null!;
    #endregion

    #region Constructors
    protected ResponseBase()
    {

    }
    #endregion

    #region Methods

    #endregion

}

public abstract class ResponseBase<T_DTO> : ResponseBase
{

    #region Attributes & Accessors
    public new abstract T_DTO Result { get; }
    #endregion

    #region Constructors
    protected ResponseBase()
    {

    }
    #endregion

    #region Methods

    #endregion

}
