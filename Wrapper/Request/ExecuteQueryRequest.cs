namespace BlazorApp1.Wrapper.Request;

public class ExecuteQueryRequest
{
    public readonly string Sql;
     public ExecuteQueryRequest(string sql)
    {
        Sql = sql;
    }

}
