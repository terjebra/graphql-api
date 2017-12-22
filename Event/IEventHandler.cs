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

namespace API.Event
{
    public interface IEventHandler
    {
      void AddRoom(Room room);
      IObservable<Room> Rooms();
    }
}
