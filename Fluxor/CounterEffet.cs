using BlazorApp1.Wrapper.ModelWrapper;
using Fluxor;

namespace BlazorApp1.Fluxor;

public class CounterEffet
{
    private IgRpcCounterServiceClient grpcCounterServiceClient {get;set;}

    public CounterEffet(IgRpcCounterServiceClient server)
    {
        grpcCounterServiceClient = server;
    }

    [EffectMethod]
    public async Task ExecuteEffet(CounterActionInput action, IDispatcher dispatcher)
    {
        var responseWrapper = await grpcCounterServiceClient.FirstWrapper(action.counter);
        
        dispatcher.Dispatch(new CounterActionOutput(responseWrapper.Content));
    }
}
