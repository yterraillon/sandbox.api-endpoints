namespace Api.TodoEndpoints;
using Application.Todo.Commands.CreateTodo;

public class Create: ApiEndpointBaseAsync<string, string>
{
    [HttpPost("/todo")]
    [SwaggerOperation(
        Summary = "Creates a new Todo",
        Description = "Creates a new Todo",
        OperationId = "CreateTodo", 
        Tags = new []{ "Todo"})] // Endpoints will be grouped under the tag in swagger UI
    public override async Task<ActionResult<string>> HandleAsync([FromBody]string request, CancellationToken cancellationToken = new ())
    {
        var response = await Mediator.Send(new CreateTodo.Request(request), cancellationToken);
        return Ok(response);
    }
}