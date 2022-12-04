namespace My.DDD.CQRS.Temp6.Domain.ExempleAggregate
{
    /// <summary>
    /// This is an exemple of how Azure Table Entities work
    /// Add as many row as you like by adding fields to this class
    /// </summary>
    public class Exemple
    {
        /// <summary>
        /// Les partitions sont le premier index cherché;
        /// pour des recherches rapides, bien penser 
        /// à quoi mettre dans la PartitionKey
        /// </summary>
        public string PartitionKey { get; set; }

        /// <summary>
        /// Deuxième index cherché en recherche rapide
        /// </summary>
        public string RowKey { get; set; }

        /// <summary>
        /// Incrément 
        /// </summary>
        public int Increment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset? Timestamp { get; set; }


        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="exampleString1"></param>
        /// <param name="exampleString1"></param>
        public Exemple(string exampleString1, string exampleString2)
        {
            PartitionKey = exampleString1;
            RowKey = exampleString2;
            Increment = 0;
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="exampleString1"></param>
        /// <param name="exampleString1"></param>
        public Exemple(string exampleString1, string exampleString2, int increment, DateTimeOffset? timeStamp)
        {
            PartitionKey = exampleString1;
            RowKey = exampleString2;
            Increment = increment;
            Timestamp = timeStamp;
        }

        public Exemple()
        {
        }
    }
}
