using System;
using System.Collections.Generic;
using API.Domain;

namespace API.Query
{
    public interface IRoomQueryService
    {
        IList<Room> GetAll();
        Room GetById(string id);
    }
}