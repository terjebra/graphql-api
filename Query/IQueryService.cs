using System;
using System.Collections.Generic;
using API.Domain;

namespace API.Query
{
    public interface IQueryService
    {
         IList<TemperatureReading> GetAll();
         TemperatureReading GetById(string id);
    }
}