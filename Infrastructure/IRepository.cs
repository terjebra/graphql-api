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
    public interface IRepository<T>
    {
      void Save(T reading);
      IList<T> GetAll();
      T Get(string id);

    }
}
