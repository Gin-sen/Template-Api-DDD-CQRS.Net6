using MY.DDD.CQRS.Temp6.CQRS.Commands;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Todos.Fake
{
    public class FakeCreateTodoCommand : ICommand<bool>
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}
