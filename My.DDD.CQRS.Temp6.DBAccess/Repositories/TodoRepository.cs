using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using My.DDD.CQRS.Temp6.Domain.SeedWork;

namespace My.DDD.CQRS.Temp6.DBAccess.Repositories
{
    public class TodoRepository : AggregateRepository<TodoAggregate>, ITodoRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public TodoRepository(ApplicationDbContext applicationDbContext, IUnitOfWork<TodoAggregate> unitOfWork) : base(unitOfWork)
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
    }
}
