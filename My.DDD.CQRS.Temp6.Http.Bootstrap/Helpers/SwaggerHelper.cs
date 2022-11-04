using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Http.Bootstrap.Helpers
{
  /// <summary>
  /// swagger helper
  /// </summary>
  public static class SwaggerHelper
  {
    /// <summary>
    /// Facilite l'écriture de la string pour SwaggerUI
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public static string UrlEndpoint(string version)
    {
      return $"/swagger/{version}/swagger.json";
    }
  }
}
