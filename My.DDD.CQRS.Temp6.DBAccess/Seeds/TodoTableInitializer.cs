using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.DBAccess.Seeds
{
  public class TodoTableInitializer
  {
    public static void Initialize(ApplicationDbContext context)
    {
      // Look for any students.
      if (context.Todos.Any())
      {
        return;   // DB has been seeded
      }

      var todos = new Todo[]
      {
        new Todo{Id = 1, Title = "Manger", Completed = false,UserId = 1},
        new Todo{Id = 2, Title = "Lire", Completed = true,UserId = 4},
        new Todo{Id = 3, Title = "Boire", Completed = true, UserId = 2},
        new Todo{Id = 4, Title = "Dormir", Completed = false, UserId = 1},
        new Todo{Id = 5, Title = "Vider", Completed = true, UserId = 1},
        new Todo{Id = 6, Title = "Coder", Completed = true, UserId = 2},
        new Todo{Id = 7,Title = "Bouger", Completed = false, UserId = 4},
        new Todo{Id = 8,Title = "Aller", Completed = true, UserId = 3}
      };

      context.Todos.AddRange(todos);
      context.SaveChanges();
    }
  }
}
