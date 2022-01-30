namespace Api;

public abstract class ApiEndpointBaseAsync<TRequest, TResponse>: EndpointBaseAsync
    .WithRequest<TRequest>
    .WithActionResult<TResponse>
{
    private IMediator _mediator = null!;
    
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}