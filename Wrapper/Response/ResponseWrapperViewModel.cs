using BlazorApp1.Wrapper.Response;

public class ResponseWrapperViewModel<T_VIEWMODEL> : ResponseWrapperBase
{

    #region Attributes & Accessors
    public T_VIEWMODEL Content { get; set; }
    #endregion

    #region Constructors
    private ResponseWrapperViewModel(ResponseBase response)
        
    {
        Content = default!;
    }
    #endregion

    #region Methods
    public static ResponseWrapperViewModel<T_VIEWMODEL> Create<T_DTO>(ResponseBase<T_DTO> response, Func<T_DTO, T_VIEWMODEL> transformer)
    {
        ResponseWrapperViewModel<T_VIEWMODEL> reponseWrapper = new(response);

        reponseWrapper.Content = transformer(response.Result);

        return reponseWrapper;
    }
    #endregion

}
