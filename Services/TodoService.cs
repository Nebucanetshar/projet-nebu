using Grpc.Core;
using grpcGreeter.Data;
using Microsoft.EntityFrameworkCore;
namespace grpcGreeter.Services;

public class TodoService : TodoIt.TodoItBase
{
    private readonly AppDbContext _dbContext;

    public TodoService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    #region CreateTodo
    public override async Task<CreateTodoResponse>CreateTodo(CreateTodoRequest request, ServerCallContext context)
    {
        if (request.Title == string.Empty || request.Description == string.Empty)
        throw new RpcException(new Status(StatusCode.InvalidArgument, "you must supply a invalid object"));

        var todoItem = new TodoItem
        {
            Titre = request.Title,
            Description = request.Description,
        };

        await _dbContext.AddAsync(todoItem);
        await _dbContext.SaveChangesAsync();

        return await Task.FromResult(new CreateTodoResponse
        {
                Id =todoItem.id
        });
    }
    #endregion

    #region ReadTodo
    public override async Task<ReadTodoResponse>ReadTodo(ReadTodoRequest request, ServerCallContext context)
    {
        if (request.Id<=0)
            throw new RpcException(new Status(StatusCode.InvalidArgument,"ressource index must be greeter than 0"));

            var todoItem = await _dbContext.todoItems.FirstOrDefaultAsync(o => o.id==request.Id);

            if (todoItem!=null)
            {
                return await Task.FromResult(new ReadTodoResponse
                {
                    Id=todoItem.id,
                    Title=todoItem.Titre,
                    Description=todoItem.Description,
                });
            }
            throw new RpcException(new Status(StatusCode.NotFound,$"No Task with id {request.Id}"));
    }
    #endregion

    #region ListTodo
    public override async Task<GetAllResponse>ListTodo(GetAllRequest request, ServerCallContext context)
    {
        var response= new GetAllResponse();
        var todoItem= await _dbContext.todoItems.ToListAsync();

        foreach (var todo in todoItem)
        {
            response.ToDo.Add(new ReadTodoResponse
            {
                Id=todo.id,
                Title=todo.Titre,
                Description=todo.Description,
            });
        }
            return await Task.FromResult(response); 
    }
    #endregion

    #region UpdateTodo
    public override async Task<UpdateTodoResponse>UpdateTodo(UpdateTodoRequest request, ServerCallContext context)
    {
        if (request.Id<=0 || request.Title == string.Empty || request.Description == string.Empty)
            throw new RpcException(new Status(StatusCode.InvalidArgument,"you must supply a valid object"));

            var todoItem = await _dbContext.todoItems.FirstOrDefaultAsync(o => o.id==request.Id);

            if (todoItem==null)
                throw new RpcException(new Status(StatusCode.NotFound,$"No Task with Id {request.Id}"));   
            
            todoItem.Titre=request.Title;
            todoItem.Description=request.Description;
            
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult(new UpdateTodoResponse
            {
                Id=todoItem.id,
            });
    }
    #endregion 

    #region DeleteTodo
    public override async Task<DeleteTodoResponse> DeleteTodo(DeleteTodoRequest request,ServerCallContext context)
    {
        if (request.Id <=0)
            throw new RpcException(new Status(StatusCode.InvalidArgument,"resource index must be greeter than 0"));

            var todoItem = await _dbContext.todoItems.FirstOrDefaultAsync(o => o.id==request.Id);

            if (todoItem== null)
                throw new RpcException(new Status(StatusCode.NotFound,$"No Task with Id{request.Id}"));

                _dbContext.Remove(todoItem);
                await _dbContext.SaveChangesAsync();
            
            return await Task.FromResult(new DeleteTodoResponse
            {
                Id=todoItem.id
            });
    }
    #endregion
}
