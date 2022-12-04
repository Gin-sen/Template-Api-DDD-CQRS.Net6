using MediatR;
using Microsoft.AspNetCore.Mvc;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Users;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users.PlaceholderApi;

namespace My.DDD.CQRS.Temp6.Api.Controllers.V1
{
  [Route("api/[controller]")]
  [ApiController]
  [ApiVersion("1")]
  public class UserController : ControllerBase
  {

    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
      _mediator = mediator;
    }


    // GET: api/<ExempleController>/placeholderapi/{id}
    [HttpGet("placeholderapi/{id}")]
    public async Task<IActionResult> GetByIdPlaceholderApiUser([FromRoute] int id)
    {
      var res = await _mediator.Send(new GetByIdUserPlaceholderApiQuery() { UserId = id });
      if (res == null)
        return NotFound();
      return Ok(res);
    }


    // GET: api/<ExempleController>/
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
      var res = await _mediator.Send(new GetAllUsersQuery());
      return Ok(res);
    }

    // GET: api/<ExempleController>/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdUser([FromRoute] int id)
    {
      var res = await _mediator.Send(new GetByIdUserQuery() { UserId = id });
      if (res == null)
        return NotFound();
      return Ok(res);
    }

    // POST: api/<ExempleController>/
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand dto)
    {
      int id = await _mediator.Send(dto);
      return Created($"/api/User/{id}", dto);
    }
  }
}
