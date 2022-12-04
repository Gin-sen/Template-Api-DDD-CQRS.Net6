using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using My.DDD.CQRS.Temp6.Domain.SeedWork;
using System.Text.Json.Serialization;

namespace My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos
{
  public class Todo : Entity, IAggregateRoot
  {

    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("completed")]
    public bool Completed { get; set; }

    public User User { get; set; }
  }
}
