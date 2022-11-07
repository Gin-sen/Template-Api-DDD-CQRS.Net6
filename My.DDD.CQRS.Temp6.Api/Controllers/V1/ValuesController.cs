using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My.DDD.CQRS.Temp6.Api.Controllers.V1
{
  [Route("api/[controller]")]
  [ApiController]
  [ApiVersion("1")]
  public class ValuesController : ControllerBase
  {
    private readonly ILogger<ValuesController> _logger;

    public ValuesController(ILogger<ValuesController> logger)
    {
      _logger = logger;
    }

    // GET: api/<ValuesController>
    [HttpGet]
    public IActionResult Get()
    {
      _logger.LogInformation("Coucou");
      return Ok(new string[] { "value1", "value2" });
    }

    // GET: api/<ValuesController>
    [HttpGet("Throw")]
    public void Throw()
    {
      _logger.LogInformation("Coucou");
      throw new Exception("CoucouException");
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      return Ok("value");
    }

    // POST api/<ValuesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
