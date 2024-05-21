using BlazorApp1.Wrapper.ModelWrapper;
using BlazorApp1.Fluxor;
using BlazorApp1.Wrapper.Request;
using Fluxor;
using Microsoft.AspNetCore.Components;
namespace BlazorApp1.Pages
{
    public partial class Counter
    {
        public int currentCount = 0;
        [Inject] private IState<CounterState> _state {get; set;}= default!;
        public void IncrementCount()
        {
            currentCount++;
        }

        // public async Task BtnExecute_Click(IDispatcher dispatcher)
        // {
        //        var sql =string.Empty;
        //         if (!string.IsNullOrEmpty(sql))
        //         {
        //             var responseServer = await gRpcCounterServiceClient.FirstWrapper(sql); // le wrapper n'est pas encore généré 
        //             dispatcher.Dispatch(new CounterActionInput(responseServer));

        //             sql=_state.Value.Response.Data;
        //         }

        // }
    }
}
