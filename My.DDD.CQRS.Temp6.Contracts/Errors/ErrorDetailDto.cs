using System.Text.Json.Serialization;

namespace My.DDD.CQRS.Temp6.Contracts.Errors
{

    /// <summary>
    /// 
    /// </summary>
    public class ErrorDetailDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("errorCode")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("errorMessage")]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("errorDescription")]
        public string Description { get; set; }
    }
}