using MY.DDD.CQRS.Temp6.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Domain.SeedWork
{
  public abstract class Entity<TId> : IEntity<TId>
  {
    private int? requestedHashCode;
    public TId? Id { get; protected set; }

    private readonly List<IEvent> events;
    public IReadOnlyCollection<IEvent> Events => events.AsReadOnly();

    protected Entity()
    {
      events = new List<IEvent>();
    }

    public void AddEvent(IEvent eventItem)
    {
      events.Add(eventItem);
    }

    public void RemoveEvent(IEvent eventItem)
    {
      events.Remove(eventItem);
    }

    public void ClearEvents()
    {
      events.Clear();
    }

    public bool IsTransient()
    {
      return EqualityComparer<TId>.Default.Equals(Id, default);
    }

    public override bool Equals(object? obj)
    {
      if (obj is not Entity<TId>)
      {
        return false;
      }

      if (ReferenceEquals(this, obj))
      {
        return true;
      }

      if (GetType() != obj.GetType())
      {
        return false;
      }

      var item = (Entity<TId>)obj;

      return !item.IsTransient() && !IsTransient() && item.Id!.Equals(Id);
    }

    public override int GetHashCode()
    {
      if (!IsTransient())
      {
        if (!requestedHashCode.HasValue)
        {
          requestedHashCode = Id!.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
        }

        return requestedHashCode.Value;
      }
      else
      {
        return base.GetHashCode();
      }
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
      return Equals(left, null) ? Equals(right, null) : left.Equals(right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
      return !(left == right);
    }
  }

  public abstract class Entity : Entity<int>
  {
  }
}
