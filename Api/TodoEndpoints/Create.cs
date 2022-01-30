namespace Api.TodoEndpoints;
using Application.Todo.Commands.CreateTodo;

public class Create: EndpointBaseAsync
    .WithRequest<string>
    .WithActionResult<string>
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator) => _mediator = mediator;

    [HttpPost("/todo")]
    [SwaggerOperation(
        Summary = "Creates a new Todo",
        Description = "Creates a new Todo",
        OperationId = "CreateTodo", 
        Tags = new []{ "Todo"})] // Endpoints will be grouped under the tag in swagger UI
    public override async Task<ActionResult<string>> HandleAsync([FromBody]string request, CancellationToken cancellationToken = new ())
    {
        var response = await _mediator.Send(new CreateTodo.Request(request), cancellationToken);
        return Ok(response);
    }
}