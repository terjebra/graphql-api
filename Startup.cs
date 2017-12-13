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
using API.Middleware;
using API.Command.Commands;

using API.Command;
using API.GraphQL;
using API.GraphQL.Types;
using API.Query;
using API.Infrastructure;

namespace API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials() );
    });
    
    
    services.AddMvc(); 
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<IRepository<Domain.TemperatureReading>, InMemoryTemperatureRepository>();
            services.AddSingleton<IRepository<Domain.Room>, InMemoryRoomRepository>();
            services.AddScoped<ITemperatureCommandService,TemperatureCommandService>();
            services.AddScoped<IRoomCommandService,RoomCommandService>();
            services.AddScoped<ITemperatureQueryService, TemperatureQueryService>();
            services.AddScoped<IRoomQueryService, RoomQueryService>();
            services.AddScoped<API.GraphQL.Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<TemperatureReading>();
            services.AddScoped<Room>();
            services.AddScoped<GraphQL.Types.RegisterTemperatureReading>();
            services.AddScoped<GraphQL.Types.RegisterRoom>();

            services.AddScoped<ISchema>(
                s => new APISchema(new FuncDependencyResolver(type => (GraphType) s.GetService(type))));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
             app.UseCors("CorsPolicy");
             
            loggerFactory.AddConsole();

            app.UseMiddleware<GraphQLMiddleware>(new GraphQLSettings
            {
                
            });
        }
    }
}
