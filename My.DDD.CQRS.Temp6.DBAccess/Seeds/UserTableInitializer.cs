using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.DBAccess.Seeds
{
  public static class UserTableInitializer
  {
    public static void Initialize(ApplicationDbContext context)
    {
      // Look for any students.
      if (context.Users.Any())
      {
        return;   // DB has been seeded
      }

      var users = new User[]
      {
        new User{Id = 1, Name="Carson",Username="Alexander",Email="truc@email.com", Phone="0101010101", Website="google.fr"},
        new User{Id = 2, Name="Meredith",Username="Alonso",Email="truc@email.com", Phone="0101010101", Website="google.fr"},
        new User{Id = 3, Name="Arturo",Username="Anand",Email="truc@email.com", Phone="0101010101", Website="google.fr"},
        new User{Id = 4, Name = "Gytis", Username = "Barzdukas", Email = "truc@email.com", Phone = "0101010101", Website = "google.fr"},
        new User{Id = 5, Name = "Yan", Username = "Li", Email = "truc@email.com", Phone = "0101010101", Website = "google.fr"},
        new User{Id = 6, Name = "Peggy", Username = "Justice", Email = "truc@email.com", Phone = "0101010101", Website = "google.fr"},
        new User{Id = 7, Name = "Laura", Username = "Norman", Email = "truc@email.com", Phone = "0101010101", Website = "google.fr"},
        new User{Id = 8, Name = "Nino", Username = "Olivetto", Email = "truc@email.com", Phone = "0101010101", Website = "google.fr"}
      };

      context.Users.AddRange(users);
      context.SaveChanges();
    }
  }
}
