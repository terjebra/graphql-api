using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GraphQL.Http;
using Microsoft.AspNetCore.Http;
using GraphQL;
using API.Command.Commands;
using API.Command;
using API.GraphQL;
using API.GraphQL.Types;
using API.Query;
using API.Infrastructure;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;

namespace API
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddSingleton<IRepository<Domain.TemperatureReading>, InMemoryTemperatureRepository>();
      services.AddSingleton<IRepository<Domain.Room>, InMemoryRoomRepository>();
      services.AddSingleton<ITemperatureCommandService, TemperatureCommandService>();
      services.AddSingleton<IRoomCommandService, RoomCommandService>();
      services.AddSingleton<ITemperatureQueryService, TemperatureQueryService>();
      services.AddSingleton<IRoomQueryService, RoomQueryService>();
      services.AddSingleton<API.GraphQL.Query>();
      services.AddSingleton<Mutation>();
      services.AddSingleton<Subscription>();
      services.AddSingleton<TemperatureReading>();
      services.AddSingleton<Room>();
      services.AddSingleton<GraphQL.Types.RegisterTemperatureReading>();
      services.AddSingleton<GraphQL.Types.RegisterRoom>();

      services.AddSingleton<APISchema>(
          s => new APISchema(new FuncDependencyResolver(type => (GraphType)s.GetService(type))));

      services.AddSingleton<API.Event.IEventHandler, API.Event.EventHandler>();
      services.AddGraphQLHttp();
      services.AddGraphQLWebSocket<APISchema>();

      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
                  builder => builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials()
              );
      });

      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseCors("CorsPolicy");

      loggerFactory.AddConsole();

      app.UseWebSockets();
      app.UseGraphQLWebSocket<APISchema>(new GraphQLWebSocketsOptions() { Path = "/api/graphql" });
      app.UseGraphQLHttp<APISchema>(
          new GraphQLHttpOptions
          {
            Path = "/api/graphql"
          }
      );

      app.UseMvc();
    }
  }
}
