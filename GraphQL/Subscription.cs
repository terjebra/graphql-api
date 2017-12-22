using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using API.Event;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;

namespace API.Query
{
    public class Subscription : ObjectGraphType<object>
    {
      private readonly IEventHandler eventHandler;

      public Subscription(IEventHandler eventHandler)
      {
        this.eventHandler = eventHandler;

        AddField(new EventStreamFieldType
        {
            Name = "roomRegistered",
            Type = typeof(GraphQL.Types.Room),
            Resolver = new FuncFieldResolver<API.Domain.Room>(ResolveRoom),
            Subscriber = new EventStreamResolver<API.Domain.Room>(Subscribe)
        });
    }

      private IObservable<API.Domain.Room> Subscribe(ResolveEventStreamContext context)
      {
          return eventHandler.Rooms();
      }

      private API.Domain.Room ResolveRoom(ResolveFieldContext context)
      {
          return context.Source as API.Domain.Room;
      }
  }
}