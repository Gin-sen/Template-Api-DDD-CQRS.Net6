using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;

namespace My.DDD.CQRS.Temp6.Api.Controllers.V1
{
  [Route("api/[controller]")]
  [ApiVersion("1")]
  [ApiController]
  public class FakeController : ControllerBase
  {
    private readonly IMediator _mediator;

    public FakeController(IMediator mediator)
    {
      _mediator = mediator;
    }



    // GET: api/<FakeController>/{id}
    [HttpGet("todos/{id}")]
    public async Task<IActionResult> FakeGetByIdTodo([FromRoute] int id)
    {
      var res = await _mediator.Send(new FakeGetByIdTodo() { TodoId = id });
      if (res == null)
        return NotFound();
      return Ok(res);
    }


    // GET: api/<FakeController>/{id}
    [HttpGet("users/{id}")]
    public async Task<IActionResult> FakeGetByIdUser([FromRoute] int id)
    {
      var res = await _mediator.Send(new FakeGetByIdUser() { UserId = id });
      if (res == null)
        return NotFound();
      return Ok(res);
    }
  }
}
