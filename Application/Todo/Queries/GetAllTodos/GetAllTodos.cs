namespace Application.Todo.Queries.GetAllTodos;

public static class GetAllTodos
{
    public record Request() : IRequest<Response>;

    public record Response(IEnumerable<string> Todos);
    
    public class Handler : IRequestHandler<Request, Response>
    {
        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var todos = new List<string>
            {
                "Id : 1234, Task : TODO1",
                "Id : 4567, Task : TODO2",
                "Id : 7891, Task : TODO3",
                "Id : 0123, Task : TODO4",
            };
            
            return Task.FromResult(new Response(todos));
        }
    }
}