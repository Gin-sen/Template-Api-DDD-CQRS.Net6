using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using My.DDD.CQRS.Temp6.Domain.SeedWork;
using System.Runtime.CompilerServices;

namespace My.DDD.CQRS.Temp6.DBAccess.Repositories
{
  public class TodoRepository : AggregateRepository<Todo>, ITodoRepository
  {
    private readonly ApplicationDbContext applicationDbContext;
    public TodoRepository(ApplicationDbContext applicationDbContext, IUnitOfWork<Todo> unitOfWork) : base(unitOfWork)
    {
      this.applicationDbContext = applicationDbContext;
    }

    public IQueryable<Todo> GetAll()
    {
      return applicationDbContext.Todos.AsQueryable();
    }

    public TodoAggregate GetTodoAggregate()
    {
      var resultat = new TodoAggregate(applicationDbContext.Todos);

      return resultat;
    }

    public async Task<int> AddTodo(Todo todo)
    {
      await this.AddAsync(todo);
      await this.SaveChangesAsync();
      return todo.Id;
    }
  }
}
