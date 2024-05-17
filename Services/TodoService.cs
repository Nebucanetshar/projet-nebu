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
        if (request.Title == string.Empty || request.Description == string.Empty) // verifie si les requêtes ne sont pas vide 
        throw new RpcException(new Status(StatusCode.InvalidArgument, "you must supply a invalid object"));
        // interruption du flux (appel à distance) ! si la condition est fausse l'exception RPC s'affiche 
                                                                                                               

        var todoItem = new TodoItem // initilisation de todoItem avec les propriétés 
        {
            Titre = request.Title,
            Description = request.Description,
        };

        await _dbContext.AddAsync(todoItem); // ajout les éléments a la base de donnée 
        await _dbContext.SaveChangesAsync();// enregistre les modifications de manière asynchrone 

        return await Task.FromResult(new CreateTodoResponse // retourne l'instance contenant l'id de l'élément nouvellement crée  
        {
                Id =todoItem.id
        });
    }
    #endregion

    #region ReadTodo
    public override async Task<ReadTodoResponse>ReadTodo(ReadTodoRequest request, ServerCallContext context)
    {
        if (request.Id<=0) // vérifie si l'id de la requête est inférieur ou égale a 0 
            throw new RpcException(new Status(StatusCode.InvalidArgument,"ressource index must be greeter than 0"));
            // interruption du flux (appel à distance) ! si la condition est fausse l'exception RPC s'affiche 

            var todoItem = await _dbContext.todoItems.FirstOrDefaultAsync(o => o.id==request.Id);
            // o représente chaque élément de la table 
            // retourne le premier élément de la table qui satisfait la condition qui vérifie si l'ID de l'élément (o.id) correspond à l'ID spécifié dans request.Id.

            if (todoItem!=null)
            {
                return await Task.FromResult(new ReadTodoResponse // retourne l'instance contenant l'id de l'élément nouvellement crée 
                {
                    Id=todoItem.id,
                    Title=todoItem.Titre,
                    Description=todoItem.Description,
                });
            }
            throw new RpcException(new Status(StatusCode.NotFound,$"No Task with id {request.Id}"));
            // indiquant que la requête demandée n'a pas été trouvée. Par exemple, si request.Id a une valeur de 123, la chaîne résultante sera "No Task with id 123".
    }
    #endregion

    #region ListTodo
    public override async Task<GetAllResponse>ListTodo(GetAllRequest request, ServerCallContext context)
    {
        var response= new GetAllResponse();
        var todoItem= await _dbContext.todoItems.ToListAsync(); 
        // récupère toutes les entrées de la table todoItems de la base de données et les renvoie sous forme de liste.
        
        foreach (var todo in todoItem) // répond à la requête tout en parcourant les éléments de la table pour ajouter les éléments suivant 
        {
            response.ToDo.Add(new ReadTodoResponse
            {
                Id=todo.id,
                Title=todo.Titre,
                Description=todo.Description,
            });
        }
            return await Task.FromResult(response); // création d'une tâche qui renvoie comme resultat le contenue de la valeurs response 
    }
    #endregion

    #region UpdateTodo
    public override async Task<UpdateTodoResponse>UpdateTodo(UpdateTodoRequest request, ServerCallContext context)
    {
        if (request.Id<=0 || request.Title == string.Empty || request.Description == string.Empty) // verifie si les requêtes ne sont pas vide 
            throw new RpcException(new Status(StatusCode.InvalidArgument,"you must supply a valid object"));
            // interruption du flux (appel à distance) ! si la condition est fausse l'exception RPC s'affiche 
            
            var todoItem = await _dbContext.todoItems.FirstOrDefaultAsync(o => o.id==request.Id);
            // o représente chaque élément de la table 
            // retourne le premier élément de la table qui satisfait la condition qui vérifie si l'ID de l'élément (o.id) correspond à l'ID spécifié dans request.Id.
            if (todoItem==null)
                throw new RpcException(new Status(StatusCode.NotFound,$"No Task with Id {request.Id}"));   
                // indiquant que la requête demandée n'a pas été trouvée. Par exemple, si request.Id a une valeur de 321, la chaîne résultante sera "No Task with id 321".
            todoItem.Titre=request.Title;
            todoItem.Description=request.Description;
            
            await _dbContext.SaveChangesAsync();// enregistre les modifications de manière asynchrone 
            
            return await Task.FromResult(new UpdateTodoResponse // création d'une tâche qui renvoie comme resultat le contenue de l'instanciation UpdateTodoResponse 
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
            // interruption du flux (appel à distance) ! si la condition est fausse l'exception RPC s'affiche 
            
            var todoItem = await _dbContext.todoItems.FirstOrDefaultAsync(o => o.id==request.Id);
             // o représente chaque élément de la table 
            // retourne le premier élément de la table qui satisfait la condition qui vérifie si l'ID de l'élément (o.id) correspond à l'ID spécifié dans request.Id.

            if (todoItem== null)
                throw new RpcException(new Status(StatusCode.NotFound,$"No Task with Id{request.Id}"));
                // indiquant que la requête demandée n'a pas été trouvée. Par exemple, si request.Id a une valeur de 321, la chaîne résultante sera "No Task with id 321".

                _dbContext.Remove(todoItem); // efface les éléments à la base de donnée 
                await _dbContext.SaveChangesAsync();// enregistre les modifications de manière asynchrone 
            
            return await Task.FromResult(new DeleteTodoResponse // création d'une tâche qui renvoie comme resultat le contenue de l'instanciation DeleteTodoResponse 
            {
                Id=todoItem.id
            });
    }
    #endregion
}
