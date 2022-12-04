using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.DBAccess
{
  public class FakeBdContext
  {
    private static List<User> _users { get; set; }
    private static List<Todo> _todos { get; set; }

    public FakeBdContext()
    {
      _users = new List<User>()
      {
        new User() { Id = 1, Name = "Bobby", Username = "Lapointe", Email = "bobby.lapointe@test.com", Phone = "0101010011", Website = "bob.fr"},
        new User() { Id = 2, Name = "Bobby2", Username = "Lapointe2", Email = "bobby.lapointe@test.com2", Phone = "01010100112", Website = "bob2.fr"},
      };
      _todos = new List<Todo>()
      {
        new Todo() { Id = 1, Title = "lorem", Completed = true, UserId = 1 },
        new Todo() { Id = 2, Title = "ipsum", Completed = false, UserId = 1 },
        new Todo() { Id = 2, Title = "hello world", Completed = true, UserId = 2 },
      };
    }


    public async Task AddUser(User product)
    {
      _users.Add(product);
      await Task.CompletedTask;
    }
    public async Task<IEnumerable<User>> GetAllUsers() => await Task.FromResult(_users);

    public async Task<User?> GetUser(int id) => await Task.FromResult(_users.FirstOrDefault(t => t.Id == id));

    public async Task AddTodo(Todo product)
    {
      _todos.Add(product);
      await Task.CompletedTask;
    }
    public async Task<IEnumerable<Todo>> GetAllTodos() => await Task.FromResult(_todos);

    public async Task<Todo?> GetTodo(int id) => await Task.FromResult(_todos.FirstOrDefault(t => t.Id == id));
  }
}
