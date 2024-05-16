namespace BlazorApp1.ViewModel;
using System.Text.Json;

public class ViewModelBase
{
    public string ToStringJson()
    {
        return JsonSerializer.Serialize(this);
    }

}

