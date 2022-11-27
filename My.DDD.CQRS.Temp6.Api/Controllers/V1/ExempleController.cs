using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Commands;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries;

namespace My.DDD.CQRS.Temp6.Api.Controllers.V1
{
  [Route("api/[controller]")]
  [ApiVersion("1")]
  [ApiController]
  public class ExempleController : ControllerBase
  {
    private readonly IMediator _mediator;

    public ExempleController(IMediator mediator)
    {
      _mediator = mediator;
    }

    // POST: api/<ExempleController>
    [HttpPost]
    public async Task<IActionResult> CreateOrIncrementExemple([FromBody] CreateOrIncrementExemple command)
    {
      var res = await _mediator.Send(command);

      return Ok(res);
    }

    // GET: api/<ExempleController>
    [HttpGet]
    public async Task<IActionResult> ListAllExemple()
    {
      var res = await _mediator.Send(new ListExemple());

      return Ok(res);
    }

    // GET: api/<ExempleController>/{exempleString}
    [HttpGet("{exempleString}")]
    public async Task<IActionResult> GetByIdExemple([FromRoute] string exempleString)
    {
      var res = await _mediator.Send(new GetByIdExemple() { ExempleString = exempleString });
      if (res == null)
        return NotFound();
      return Ok(res);
    }
  }
}
