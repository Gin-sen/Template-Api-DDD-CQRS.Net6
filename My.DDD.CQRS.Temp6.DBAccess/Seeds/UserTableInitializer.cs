using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;

namespace My.DDD.CQRS.Temp6.DBAccess.Seeds
{
  public static class UserTableInitializer
  {
    public static async Task Initialize(ApplicationDbContext context, IPlaceholderClient client)
    {
      // Look for any students.
      if (context.Users.Any())
      {
        return;   // DB has been seeded
      }
      User? res = null;
      var users = new List<User>();
      int index = 1;
      res = await client.GetUser(index);
      while (res != null)
      {
        users.Add(res);
        index++;
        res = await client.GetUser(index);
      }

      //var users = new User[]
      //{
      //  new User{Id = 1, Name="Carson",Username="Alexander",Email="truc@email.com", Phone="0101010101", Website="google.fr"},
      //  new User{Id = 2, Name="Meredith",Username="Alonso",Email="truc@email.com", Phone="0101010101", Website="google.fr"},
      //  new User{Id = 3, Name="Arturo",Username="Anand",Email="truc@email.com", Phone="0101010101", Website="google.fr"},
      //  new User{Id = 4, Name = "Gytis", Username = "Barzdukas", Email = "truc@email.com", Phone = "0101010101", Website = "google.fr"},
      //  new User{Id = 5, Name = "Yan", Username = "Li", Email = "truc@email.com", Phone = "0101010101", Website = "google.fr"},
      //  new User{Id = 6, Name = "Peggy", Username = "Justice", Email = "truc@email.com", Phone = "0101010101", Website = "google.fr"},
      //  new User{Id = 7, Name = "Laura", Username = "Norman", Email = "truc@email.com", Phone = "0101010101", Website = "google.fr"},
      //  new User{Id = 8, Name = "Nino", Username = "Olivetto", Email = "truc@email.com", Phone = "0101010101", Website = "google.fr"}
      //};

      context.Users.AddRange(users);
      context.SaveChanges();
    }
  }
}
