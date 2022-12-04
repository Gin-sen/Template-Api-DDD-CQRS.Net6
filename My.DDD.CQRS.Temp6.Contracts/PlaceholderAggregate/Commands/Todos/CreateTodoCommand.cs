using MY.DDD.CQRS.Temp6.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Todos
{
  public class CreateTodoCommand : ICommand<int>
  {
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("completed")]
    public bool Completed { get; set; }
  }
}
