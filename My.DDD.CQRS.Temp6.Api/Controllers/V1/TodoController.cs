using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos;

namespace My.DDD.CQRS.Temp6.Api.Controllers.V1
{
  [Route("api/[controller]")]
  [ApiVersion("1")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
      _mediator = mediator;
    }


    // GET: api/<ExempleController>/{id}
    [HttpGet("placeholderapi/{id}")]
    public async Task<IActionResult> GetByIdTodo([FromRoute] int id)
    {
      var res = await _mediator.Send(new GetByIdTodo() { TodoId = id });
      if (res == null)
        return NotFound();
      return Ok(res);
    }
  }
}
