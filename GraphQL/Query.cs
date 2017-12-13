using API.GraphQL.Types;
using GraphQL.Types;
using System.Collections.Generic;
using API.Query;

namespace API.GraphQL
{
  public class Query : ObjectGraphType<object>
  {
    private readonly ITemperatureQueryService temperatureQueryService;
    private readonly IRoomQueryService roomQueryService;

    public Query(ITemperatureQueryService temperatureQueryService, IRoomQueryService roomQueryService)
    {
      this.temperatureQueryService = temperatureQueryService;
      this.roomQueryService = roomQueryService;
      Name = "Query";

      
      Field<ListGraphType<TemperatureReading>>("temperatureReadings",
        resolve: context => temperatureQueryService.GetAll());


      Field<TemperatureReading>("temperatureReading", 
       arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the reading" }
                ),
        resolve: context => temperatureQueryService.GetById(context.GetArgument<string>("id"))
      );

      Field<ListGraphType<Room>>("rooms",
        resolve: context => roomQueryService.GetAll());


      Field<Room>("room",
        arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the room" } ),
        resolve: context => roomQueryService.GetById(context.GetArgument<string>("id"))
      );
    }
    
  }
}