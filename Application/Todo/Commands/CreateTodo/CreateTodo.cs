namespace Application.Todo.Commands.CreateTodo;

public static class CreateTodo
{
    public record Request(string Name) : IRequest<Response>;

    public record Response(string Id);
    
    public class Handler : IRequestHandler<Request, Response>
    {
        public Task<Response> Handle(Request request, CancellationToken cancellationToken) => 
            Task.FromResult(new Response($"1234 - {request.Name}"));
    }
}