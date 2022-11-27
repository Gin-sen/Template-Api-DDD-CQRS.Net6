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

    // GET: api/<ExempleController>/CreateOrUpdate
    [HttpGet("CreateOrUpdate")]
    public async Task<IActionResult> CreateOrIncrementExemple([FromQuery] CreateOrIncrementExemple command)
    {
      var res = await _mediator.Send(command);

      return Ok(res);
    }

    // GET: api/<ExempleController>/List
    [HttpGet("List")]
    public async Task<IActionResult> ListAllExemple()
    {
      var res = await _mediator.Send(new ListExemple());

      return Ok(res);
    }
  }
}
