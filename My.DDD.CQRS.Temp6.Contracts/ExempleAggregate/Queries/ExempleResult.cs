namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries
{
    public class ExempleResult
    {
        public int Increment { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? TimeStamp { get; set; }
    }
}
