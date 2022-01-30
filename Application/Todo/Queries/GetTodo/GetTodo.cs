namespace Application.Todo.Queries.GetTodo;

public static class GetTodo
{
    public record Request(string Id) : IRequest<Response>;

    public record Response(string Todo);
    
    public class Handler : IRequestHandler<Request, Response>
    {
        public Task<Response> Handle(Request request, CancellationToken cancellationToken) => 
            Task.FromResult(new Response($"Id : {request.Id}, Task : TODO"));
    }
}