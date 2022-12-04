using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Users.Fake;
using My.DDD.CQRS.Temp6.DBAccess;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using MY.DDD.CQRS.Temp6.CQRS.Commands;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Commands.Users.Fake
{
    public class FakeCreateUserCommandHandler : ICommandHandler<FakeCreateUserCommand, bool>
    {
        private readonly FakeBdContext _fakeDbContext;

        public FakeCreateUserCommandHandler(FakeBdContext fakeDbContext)
        {
            _fakeDbContext = fakeDbContext;
        }

        public async Task<bool> Handle(FakeCreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _fakeDbContext.AddUser(new User()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Email = request.Email,
                    Address = request.Address,
                    Company = request.Company,
                    Username = request.Username,
                    Phone = request.Phone,
                    Website = request.Website
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
