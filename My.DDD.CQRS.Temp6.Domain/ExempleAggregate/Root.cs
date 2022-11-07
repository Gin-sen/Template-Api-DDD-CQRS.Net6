using My.DDD.CQRS.Temp6.AzureTables.Entities;
using My.DDD.CQRS.Temp6.CQRS.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Domain.ExempleAggregate
{
  public class Root : IAggregateRoot
  {
    public IQueryable<Exemple> Exemples{ get; private set; }

    public Root(IQueryable<Exemple> exemples)
    {
      Exemples = exemples;
    }

    public async Task<Exemple> GetExempleAsync(string exempleString1, string exempleString2, CancellationToken cancellationToken)
    {
      await Task.Delay(1);
      var resultat = Exemples
        .FirstOrDefault(e => e.PartitionKey == exempleString1 && e.RowKey == exempleString2);
      return resultat;
    }

    public async Task<IList<Exemple>> ListExempleAsync(string exempleString1, CancellationToken cancellationToken)
    {
      await Task.Delay(1);
      var resultats = Exemples
        .Where(e => e.RowKey == exempleString1 || e.PartitionKey == exempleString1).ToList();

      return resultats;
    }
  }
}
