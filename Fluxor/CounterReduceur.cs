using Fluxor;

namespace BlazorApp1.Fluxor;

public static class CounterReducer
{
    [ReducerMethod]
    public static CounterState ExecuteState(CounterState state, CounterActionOutput action)
    {
        return state with
        {
            Response= action.ResponseServer
        };
    }
}
