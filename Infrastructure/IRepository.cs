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
    public interface IRepository
    {
      void Save(TemperatureReading reading);
      IList<TemperatureReading> GetAll();
      TemperatureReading Get(string id);
    }
}
