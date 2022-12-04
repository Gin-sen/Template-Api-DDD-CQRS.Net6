using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using MY.DDD.CQRS.Temp6.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Users
{
  public class CreateUserCommand : ICommand<int>
  {

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("website")]
    public string Website { get; set; }


  }
}
