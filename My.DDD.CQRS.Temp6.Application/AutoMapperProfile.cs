using AutoMapper;
using My.DDD.CQRS.Temp6.AzureTables.Entities;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries;

namespace My.DDD.CQRS.Temp6.Application
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Exemple, ListExempleResult>();
    }
  }

}