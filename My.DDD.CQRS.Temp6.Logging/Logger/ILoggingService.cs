using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Logging.Logger
{
  public interface ILoggingService
  {

    /// <summary>
    /// Log en Information dans Application Insights et Elastic Search
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="fields">The fields.</param>
    void TrackInfo(string message, params object[] fields);


    /// <summary>
    /// Log en Exception dans Application Insights et Elastic Search
    /// </summary>
    /// <param name="message"></param>
    /// <param name="ex"></param>
    /// <param name="fields"></param>
    void TrackException(string message, Exception ex, params object[] fields);

    /// <summary>
    /// Log en Exception dans Application Insights et Elastic Search
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="fields">The fields.</param>
    void TrackError(string message, params object[] fields);
  }
}
