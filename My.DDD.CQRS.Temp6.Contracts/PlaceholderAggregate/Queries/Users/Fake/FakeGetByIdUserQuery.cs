using MediatR;
using MY.DDD.CQRS.Temp6.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users.Fake
{
  public class FakeGetByIdUserQuery : IQuery<UserResult?>
  {

    public int UserId { get; set; }
  }
}
