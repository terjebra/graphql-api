using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace API.Infrastructure
{
    public class InMemoryRepository : IRepository
    {
      private readonly IList<TemperatureReading> _readings;

      public InMemoryRepository()
      {
          _readings = new List<TemperatureReading>();
      }

    public IList<TemperatureReading> GetAll()
    {
     return _readings;
    }

    public TemperatureReading Get(string id)
    {
      return _readings.FirstOrDefault(x => x.Id.Equals(id));
    }

    public void Save(TemperatureReading reading)
    {
      _readings.Add(reading);
    }
  }
}
