using BlazorApp1.ViewModel;
using Fluxor;

namespace BlazorApp1.Fluxor;

[FeatureState]
public record CounterState
{
    public ResultResponseViewModel Response { get; set; }

    public CounterState()
    {
        Response = new ResultResponseViewModel();
    }


}
