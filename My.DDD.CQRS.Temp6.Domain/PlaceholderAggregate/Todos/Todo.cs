using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos
{
  public class Todo
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
