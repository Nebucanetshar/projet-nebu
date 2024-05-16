namespace BlazorApp1.Request;

public class ExecuteQueryRequest
{
    public readonly string Sql;
     public ExecuteQueryRequest(string sql)
    {
        Sql = sql;
    }

}
