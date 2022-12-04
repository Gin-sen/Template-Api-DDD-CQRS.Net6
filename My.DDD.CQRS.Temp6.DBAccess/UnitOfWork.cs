using My.DDD.CQRS.Temp6.DBAccess.Repositories;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.DBAccess
{
  public class UnitOfWork : IDisposable
  {
    private ApplicationDbContext context;

    public UnitOfWork(ApplicationDbContext context)
    {
      this.context = context;
    }

    private GenericApplicationDbRepository<User> userRepository;
    public GenericApplicationDbRepository<User> UserRepository
    {
      get
      {
        return this.userRepository ?? new GenericApplicationDbRepository<User>(context);
      }
    }
    public void Save()
    {
      context.SaveChanges();
    }
    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          context.Dispose();
        }
      }
      this.disposed = true;
    }
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}