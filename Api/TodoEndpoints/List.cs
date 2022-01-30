namespace Api.TodoEndpoints;
using Application.Todo.Queries.GetAllTodos;

public class List: EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<IEnumerable<string>>
{
    private readonly IMediator _mediator;

    public List(IMediator mediator) => _mediator = mediator;

    [HttpGet("/todos")]
    [SwaggerOperation(
        Summary = "Gets all Todos",
        Description = "Gets all Todos",
        OperationId = "GetAllTodos", 
        Tags = new []{ "Todo"})] // Endpoints will be grouped under the tag in swagger UI
    public override async Task<ActionResult<IEnumerable<string>>> HandleAsync(CancellationToken cancellationToken = new ())
    {
        var response = await _mediator.Send(new GetAllTodos.Request(), cancellationToken);
        return Ok(response);
    }
}