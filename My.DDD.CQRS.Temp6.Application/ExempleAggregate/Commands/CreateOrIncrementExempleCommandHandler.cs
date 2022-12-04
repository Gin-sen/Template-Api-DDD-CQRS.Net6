using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Commands;
using My.DDD.CQRS.Temp6.Domain.ExempleAggregate;
using MY.DDD.CQRS.Temp6.CQRS.Commands;

namespace My.DDD.CQRS.Temp6.Application.ExempleAggregate.Commands
{
    public class CreateOrIncrementExempleCommandHandler :
                            ICommandHandler<CreateOrIncrementExempleCommand, CreateOrIncrementResult>
    {
        private readonly IExempleService _exempleRepository;

        public CreateOrIncrementExempleCommandHandler(IExempleService exempleRepository)
        {
            _exempleRepository = exempleRepository;
        }

        public async Task<CreateOrIncrementResult> Handle(CreateOrIncrementExempleCommand request,
          CancellationToken cancellationToken)
        {
            await _exempleRepository.AddAsync(request.StringExemple, cancellationToken);
            var result = await _exempleRepository.GetAsync(request.StringExemple, cancellationToken);
            return new CreateOrIncrementResult() { StringExemple = result.PartitionKey, Increment = result.Increment };
        }
    }
}
