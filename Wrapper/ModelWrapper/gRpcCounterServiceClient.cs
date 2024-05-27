using BlazorApp1.ViewModel;
using BlazorApp1.Wrapper.Request;

namespace BlazorApp1.Wrapper.ModelWrapper;

public interface IgRpcCounterServiceClient
{
    Task<ResponseWrapperViewModel<CounterViewModel>>CreateTodo(string arg);
}
// public class gRpcCounterServiceClient
// {
//     Task<ResponseWrapperViewModel<CounterViewModel>>CreateTodo(string arg)
//     {
//         CreateTodoRequest request= new CreateTodoRequest(arg);  
//         var responseServer= await grpc.CreateTodo(request); 
//         var responseEffet=ResponseWrapperViewModel<CounterViewModel>.Create(responseServer,dto => new CounterViewModel(dto));
        
//         await ProcessMessages(responseEffet); // affichage messages 
        
//         return responseEffet; 
//     }

// }
