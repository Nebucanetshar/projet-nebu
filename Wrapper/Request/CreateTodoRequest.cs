namespace BlazorApp1.Wrapper.Request;

public partial class CreateTodoRequest
{
    public readonly string Sql;
     public CreateTodoRequest(string sql)
    {
        Sql = sql;
    }

}
