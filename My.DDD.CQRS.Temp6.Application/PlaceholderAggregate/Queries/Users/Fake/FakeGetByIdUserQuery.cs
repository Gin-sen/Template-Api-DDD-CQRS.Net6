using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users.Fake;
using My.DDD.CQRS.Temp6.DBAccess;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Users.Fake
{
    public class FakeGetByIdUserQuery : IRequestHandler<FakeGetByIdUser, UserResult?>
    {
        private readonly FakeBdContext _fakeDbContext;
        public FakeGetByIdUserQuery(FakeBdContext fakeDbContext)
        {
            _fakeDbContext = fakeDbContext;
        }

        public async Task<UserResult?> Handle(FakeGetByIdUser request, CancellationToken cancellationToken)
        {
            var result = await _fakeDbContext.GetUser(request.UserId);
            if (result == null)
                return null;
            return new UserResult() { Id = result.Id, Name = result.Name, Email = result.Email, Username = result.Username, Phone = result.Phone, Website = result.Website };
        }
    }
}
