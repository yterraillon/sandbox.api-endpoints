using Application.Todo.Commands.CreateTodo;
using Application.Todo.Commands.DeleteTodo;
using Application.Todo.Queries.GetAllTodos;
using Application.Todo.Queries.GetTodo;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldTodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OldTodoController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllTodos.Request());
            return Ok(response);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _mediator.Send(new GetTodo.Request(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            var response = await _mediator.Send(new CreateTodo.Request(value));
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new DeleteTodo.Request(id));
            return Ok(response);
        }
    }
}
