using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;

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


    // GET: api/<ExempleController>/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdUser([FromRoute] int id)
    {
      var res = await _mediator.Send(new GetByIdUser() { UserId = id });
      if (res == null)
        return NotFound();
      return Ok(res);
    }
  }
}
