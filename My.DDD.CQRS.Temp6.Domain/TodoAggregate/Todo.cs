using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Domain.TodoAggregate
{
  public class Todo
  {

    [JsonPropertyName("userId")]
    public int UserId;

    [JsonPropertyName("id")]
    public int Id;

    [JsonPropertyName("title")]
    public string Title;

    [JsonPropertyName("completed")]
    public bool Completed;
  }
}
