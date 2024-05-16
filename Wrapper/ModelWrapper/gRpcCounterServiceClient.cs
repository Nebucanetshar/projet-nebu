using BlazorApp1.ViewModel;

namespace BlazorApp1.Wrapper.ModelWrapper;

public interface IgRpcCounterServiceClient
{
    Task<ResponseWrapperViewModel<CounterViewModel>> FirstWrapper(string arg);
}
public class gRpcCounterServiceClient
{
    // Task<ResponseWrapperViewModel<CounterViewModel>> FirstWrapper(string arg)
    // {
    //     ExecuteQueryRequest request= new ExecuteQueryRequest(arg);  // création class partial ExecuteQueryRequest.proto
    //     var responseServer= await GrpcClient.FirstWrapper(request); // création GrpcClient.proto
    //     var responseEffet=ResponseWrapperViewModel<CounterViewModel>.Create(responseServer,dto => new CounterViewModel(dto));
        
    //     await ProcessMessages(responseEffet); // affichage message 
        
    //     return responseEffet; 
    // }

}
