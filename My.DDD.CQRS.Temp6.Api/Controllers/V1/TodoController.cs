using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.DDD.CQRS.Temp6.Contracts.TodoAggregate.Queries;

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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdTodo([FromRoute] int id)
    {
      var res = await _mediator.Send(new GetByIdTodo());
      if (res == null)
        return NotFound();
      return Ok(res);
    }
  }
}
