using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.LogModels
{
  /// <summary>
  ///
  /// </summary>
  public class URSSAFLog
  {
    /// <summary>
    /// Methode qui appelle le log
    /// </summary>
    public string Method { get; set; }

    /// <summary>
    /// Command qui appelle le log
    /// </summary>
    public string Command { get; set; }

    /// <summary>
    /// Query qui appelle le log
    /// </summary>
    public string Query { get; set; }


  }
}
