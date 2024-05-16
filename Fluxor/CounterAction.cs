using BlazorApp1.ViewModel;
namespace BlazorApp1.Fluxor;

public class CounterActionOutput
{
    public ResultResponseViewModel ResponseServer;
    public CounterViewModel Content { get; }

    public CounterActionOutput(ResultResponseViewModel responseServer)
    {
        ResponseServer = responseServer;
    }  

    public CounterActionOutput(CounterViewModel content)
    {
        Content = content;
    }
}

public class CounterActionInput
{
    public string counter {get; set;}

    public CounterActionInput (string counter)
    {
        this.counter = counter;
    }
}
