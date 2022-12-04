using MY.DDD.CQRS.Temp6.CQRS.Commands;

namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Commands
{
    public class CreateOrIncrementExempleCommand : ICommand<CreateOrIncrementResult>
    {
        public string StringExemple { get; set; }

    }
}
