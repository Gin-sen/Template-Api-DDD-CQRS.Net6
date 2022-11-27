using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Commands;

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
    public async Task<IActionResult> Get([FromQuery] CreateOrIncrementExemple query)
    {
      var res = await _mediator.Send(query);

      return Ok(res);
    }
  }
}
