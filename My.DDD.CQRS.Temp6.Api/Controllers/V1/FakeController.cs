using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Todos.Fake;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Users.Fake;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos.Fake;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users.Fake;

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

    #region CRUD_TODOS

    // GET: api/<FakeController>/{id}
    [HttpGet("todos/{id}")]
    public async Task<IActionResult> FakeGetByIdTodo([FromRoute] int id)
    {
      var res = await _mediator.Send(new FakeGetByIdTodo() { TodoId = id });
      if (res == null)
        return NotFound();
      return Ok(res);
    }


    // GET: api/<FakeController>/todos
    [HttpGet("todos")]
    public async Task<IActionResult> FakeAllTodos()
    {
      var res = await _mediator.Send(new FakeGetAllTodos());
      if (res == null)
        return NotFound();
      return Ok(res);
    }


    // POST: api/<FakeController>/todos
    [HttpPost("todos")]
    public async Task<IActionResult> FakeCreateTodo([FromBody] FakeCreateTodo dto)
    {
      var res = await _mediator.Send(dto);
      if (!res)
        return BadRequest();
      return Created($"{dto.Id}", dto);
    }
      #endregion

      #region CRUD_USERS
      // GET: api/<FakeController>/users/{id}
      [HttpGet("users/{id}")]
    public async Task<IActionResult> FakeGetByIdUser([FromRoute] int id)
    {
      var res = await _mediator.Send(new FakeGetByIdUser() { UserId = id });
      if (res == null)
        return NotFound();
      return Ok(res);
    }


    // GET: api/<FakeController>/users
    [HttpGet("users")]
    public async Task<IActionResult> FakeAllUsers()
    {
      var res = await _mediator.Send(new FakeGetAllUsers());
      if (res == null)
        return NotFound();
      return Ok(res);
    }

    // POST: api/<FakeController>/todos
    [HttpPost("users")]
    public async Task<IActionResult> FakeCreateUser([FromBody] FakeCreateUser dto)
    {
      var res = await _mediator.Send(dto);
      if (!res)
        return BadRequest();
      return Created($"{dto.Id}", dto);
    }
    #endregion
  }
}
