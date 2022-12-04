using System.Text.Json.Serialization;

namespace My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users
{
  public class Geo
  {
    [JsonPropertyName("lat")]
    public string Lat { get; set; }

    [JsonPropertyName("lng")]
    public string Lng { get; set; }
  }
}
