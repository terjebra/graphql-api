using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using API.Domain;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reactive.Linq;

namespace API.Event
{
  public class EventHandler : IEventHandler
  {
    private readonly ISubject<Room> _messageStream = new ReplaySubject<Room>(1);

    public void AddRoom(Room room)
    {
       _messageStream.OnNext(room);
    }

    public IObservable<Room> Rooms()
    {
      return _messageStream.AsObservable();
    }
  }
}
