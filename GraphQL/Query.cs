using API.GraphQL.Types;
using GraphQL.Types;
using System.Collections.Generic;
using API.Query;

namespace API.GraphQL
{
  public class Query : ObjectGraphType<object>
  {
    private readonly IQueryService queryService;
    public Query(IQueryService queryService)
    {
      this.queryService = queryService;
      Name = "Query";

      
      Field<ListGraphType<TemperatureReading>>("temperatureReadings",
        resolve: context => queryService.GetAll());


      Field<TemperatureReading>("temperatureReading", 
       arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the human" }
                ),
        resolve: context => queryService.GetById(context.GetArgument<string>("id"))
      );
    }
    
  }
}