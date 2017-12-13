using System;
using System.Collections.Generic;
using API.Domain;
using System.Linq;
using API.Infrastructure;

namespace API.Query
{
  public class TemperatureQueryService : ITemperatureQueryService
  {
    private readonly IRepository<TemperatureReading> repository;

    public TemperatureQueryService(IRepository<TemperatureReading>  repository)
    {
      this.repository = repository;

    }
    public System.Collections.Generic.IList<TemperatureReading> GetAll()
    {
      return repository.GetAll();
    }

    public TemperatureReading GetById(string id)
    {
      return repository.Get(id);
    }
  }
}