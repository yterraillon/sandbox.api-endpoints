namespace Application.Todo.Commands.DeleteTodo;

public static class DeleteTodo
{
    public record Request(string Id) : IRequest<Response>;

    public record Response(bool Deleted);
    
    public class Handler : IRequestHandler<Request, Response>
    {
        public Task<Response> Handle(Request request, CancellationToken cancellationToken) => 
            Task.FromResult(new Response(true));
    }
}