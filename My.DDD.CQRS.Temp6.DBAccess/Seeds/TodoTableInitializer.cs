using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;

namespace My.DDD.CQRS.Temp6.DBAccess.Seeds
{
    public class TodoTableInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, IPlaceholderClient client)
        {
            // Look for any students.
            if (context.Todos.Any())
            {
                return;   // DB has been seeded
            }
            Todo? res = null;
            var todos = new List<Todo>();
            int index = 1;
            res = await client.GetTodo(index);
            while (res != null)
            {
                todos.Add(res);
                index++;
                res = await client.GetTodo(index);
            }
            //var todos = new Todo[]
            //{
            //  new Todo{Id = 1, Title = "Manger", Completed = false,UserId = 1},
            //  new Todo{Id = 2, Title = "Lire", Completed = true,UserId = 4},
            //  new Todo{Id = 3, Title = "Boire", Completed = true, UserId = 2},
            //  new Todo{Id = 4, Title = "Dormir", Completed = false, UserId = 1},
            //  new Todo{Id = 5, Title = "Vider", Completed = true, UserId = 1},
            //  new Todo{Id = 6, Title = "Coder", Completed = true, UserId = 2},
            //  new Todo{Id = 7,Title = "Bouger", Completed = false, UserId = 4},
            //  new Todo{Id = 8,Title = "Aller", Completed = true, UserId = 3}
            //};

            context.Todos.AddRange(todos);
            context.SaveChanges();
        }
    }
}
