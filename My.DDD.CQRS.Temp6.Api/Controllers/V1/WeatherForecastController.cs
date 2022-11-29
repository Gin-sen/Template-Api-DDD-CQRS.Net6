using MediatR;
using Microsoft.AspNetCore.Mvc;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Notifications;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Queries;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Streams;

namespace My.DDD.CQRS.Temp6.Api.Controllers.V1
{
    [ApiController]
  [Route("api/[controller]")]
  [ApiVersion("1")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly IMediator _mediator;

    public WeatherForecastController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
      var res = await _mediator.Send(new GetWeatherForecast());
      if (res.Count() == 0)
        return NotFound();
      return Ok(res);
    }


    [HttpPost(Name = "WeatherWarning")]
    public async Task<IActionResult> CreateWarning([FromBody] CreateWeatherWarning createWeatherWarning)
    {
      await _mediator.Publish(createWeatherWarning);
      return Ok();
    }
    [HttpGet("WeatherUpdates/{city}")]
    public IAsyncEnumerable<WeatherForecastResult> GetWeatherUpdates([FromRoute] string city, CancellationToken cancellationToken)
    {
      var streamRequest = new GetWeatherUpdates() { City = city };
      return _mediator.CreateStream(streamRequest, cancellationToken);
    }

  }
}