using API.Command;
using API.GraphQL.Types;
using API.Query;
using GraphQL.Types;

namespace API.GraphQL
{
  public class Mutation : ObjectGraphType<object>
  {
    private readonly ICommandService commandService;
    private readonly IQueryService queryService;
    public Mutation(ICommandService commandService,
     IQueryService queryService)
    {
      this.commandService = commandService;
      this.queryService = queryService;
      Name = "Mutation";

    
      Field<TemperatureReading>(
        "registerReading",
        arguments: new QueryArguments(
            new QueryArgument<NonNullGraphType<RegisterTemperatureReading>> {Name = "temperatureReading"}
        ),
        resolve: context =>
        {
            var command = context.GetArgument<API.Command.Commands.RegisterTemperatureReading>("temperatureReading");
            
            var id = this.commandService.RegisterReading(command);
            return queryService.GetById(id);
        });
    }
  }
}