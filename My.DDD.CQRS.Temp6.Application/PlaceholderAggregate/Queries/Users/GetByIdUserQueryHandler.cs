using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate;
using MY.DDD.CQRS.Temp6.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Users
{
  public class GetByIdUserQueryHandler : IQueryHandler<GetByIdUserQuery, UserResult?>
  {
    private readonly IPlaceholderClient _placeholderClient;

    public GetByIdUserQueryHandler(IPlaceholderClient placeholderClient)
    {
      _placeholderClient = placeholderClient;
    }

    public async Task<UserResult?> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
      var result = await _placeholderClient.GetUser(request.UserId);
      if (result == null)
        return null;
      return new UserResult() { Id = result.Id, Name = result.Name, Email = result.Email, Username = result.Username, Phone = result.Phone, Website = result.Website };
    }
  }
}
