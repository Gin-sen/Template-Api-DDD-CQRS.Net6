using MediatR;
using Microsoft.AspNetCore.Mvc;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Todos;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos.PlaceholderApi;

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


    // GET: api/<ExempleController>/placeholderapi/{id}
    [HttpGet("placeholderapi/{id}")]
    public async Task<IActionResult> GetByIdPlaceholderApiTodo([FromRoute] int id)
    {
      var res = await _mediator.Send(new GetByIdTodoPlaceholderApiQuery() { TodoId = id });
      if (res == null)
        return NotFound();
      return Ok(res);
    }
    // GET: api/<ExempleController>/
    [HttpGet]
    public async Task<IActionResult> GetAllTodos()
    {
      var res = await _mediator.Send(new GetAllTodosQuery());
      return Ok(res);
    }

    // GET: api/<ExempleController>/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdTodo([FromRoute] int id)
    {
      var res = await _mediator.Send(new GetByIdTodoQuery() { TodoId = id });
      if (res == null)
        return NotFound();
      return Ok(res);
    }


    // POST: api/<ExempleController>/
    [HttpPost]
    public async Task<IActionResult> CreateTodo([FromBody] CreateTodoCommand dto)
    {
      int id = await _mediator.Send(dto);
      return Created($"/api/Todo/{id}", dto);
    }
  }
}
