using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.Errors
{
  /// <summary>
  /// Retour d'erreur API REST
  /// </summary>
  public class ErrorResponseDto
  {
    /// <summary>
    /// Type de l'erreur
    /// </summary>
    [JsonPropertyName("errorType")]
    public string ErrorType { get; set; }

    /// <summary>
    /// Titre de l'erreur
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// Message de l'erreur
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Origin
    /// </summary>
    [JsonPropertyName("origin")]
    public string Origin { get; set; }

    /// <summary>
    /// Errors
    /// </summary>
    [JsonPropertyName("errors")]
    public List<ErrorDetailDto> Errors { get; set; } = new List<ErrorDetailDto>();
  }

}
