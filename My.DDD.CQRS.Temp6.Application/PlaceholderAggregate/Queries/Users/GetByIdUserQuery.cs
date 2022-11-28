using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Users
{
  public class GetByIdUserQuery : IRequestHandler<GetByIdUser, UserResult?>
  {
    private readonly IPlaceholderClient _placeholderClient;

    public GetByIdUserQuery(IPlaceholderClient placeholderClient)
    {
      _placeholderClient = placeholderClient;
    }

    public async Task<UserResult?> Handle(GetByIdUser request, CancellationToken cancellationToken)
    {
      var result = await _placeholderClient.GetUser(request.UserId);
      if (result == null)
        return null;
      return new UserResult() { Id = result.Id, Name = result.Name, Email = result.Email, Username = result.Username, Phone = result.Phone, Website = result.Website };
    }
  }
}
