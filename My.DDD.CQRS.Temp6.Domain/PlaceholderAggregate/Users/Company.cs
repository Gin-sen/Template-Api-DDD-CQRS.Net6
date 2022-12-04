using System.Text.Json.Serialization;

namespace My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users
{
  public class Company
  {
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("catchPhrase")]
    public string CatchPhrase { get; set; }

    [JsonPropertyName("bs")]
    public string Bs { get; set; }
  }
}
