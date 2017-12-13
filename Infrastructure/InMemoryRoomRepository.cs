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
    public class InMemoryRoomRepository :  IRepository<Room>
    {
      private readonly IList<Room> rooms;

      public InMemoryRoomRepository()
      {
          rooms = new List<Room>();
      }

      public IList<Room> GetAll()
      {
      return rooms;
      }

      public Room Get(string id)
      {
        return rooms.FirstOrDefault(x => x.Id.Equals(id));
      }

      public void Save(Room reading)
      {
        rooms.Add(reading);
      }
  }
}
