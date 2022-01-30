namespace Api.TodoEndpoints;
using Application.Todo.Queries.GetTodo;

public class Get : EndpointBaseAsync
    .WithRequest<string>
    .WithActionResult<string>
{
    private readonly IMediator _mediator;

    public Get(IMediator mediator) => _mediator = mediator;

    [HttpGet("/todo/{id}")]
    [SwaggerOperation(
        Summary = "Gets a Todo",
        Description = "Gets a Todo",
        OperationId = "GetTodo", 
        Tags = new []{ "Todo"})] // Endpoints will be grouped under the tag in swagger UI
    public override async Task<ActionResult<string>> HandleAsync(string id, CancellationToken cancellationToken = new ())
    {
        var response = await _mediator.Send(new GetTodo.Request(id), cancellationToken);
        return Ok(response);
    }
}