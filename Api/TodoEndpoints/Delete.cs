namespace Api.TodoEndpoints;
using Application.Todo.Commands.DeleteTodo;

public class Delete : EndpointBaseAsync
    .WithRequest<string>
    .WithActionResult<string>
{
    private readonly IMediator _mediator;

    public Delete(IMediator mediator) => _mediator = mediator;

    [HttpDelete("/todo")]
    [SwaggerOperation(
        Summary = "Deletes a Todo",
        Description = "Deletes a Todo",
        OperationId = "DeleteTodo", 
        Tags = new []{ "Todo"})] // Endpoints will be grouped under the tag in swagger UI
    public override async Task<ActionResult<string>> HandleAsync([FromQuery] string id, CancellationToken cancellationToken = new ())
    {
        var response = await _mediator.Send(new DeleteTodo.Request(id), cancellationToken);
        return Ok(response);
    }
}