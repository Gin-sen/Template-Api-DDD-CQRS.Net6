using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users.Fake
{
  public class FakeGetByIdUserQuery : IRequest<UserResult?>
  {

    public int UserId { get; set; }
  }
}
