using API.Command;
using API.GraphQL.Types;
using API.Query;
using GraphQL.Types;

namespace API.GraphQL
{
  public class Mutation : ObjectGraphType<object>
  {
        private readonly ITemperatureCommandService temperatureCommandService;
        private readonly ITemperatureQueryService temperatureQueryService;
        private readonly IRoomCommandService roomCommandService;
        private readonly IRoomQueryService roomQueryService;

        public Mutation(
            ITemperatureCommandService temperatureCommandService,
            ITemperatureQueryService temperatureQueryService,
            IRoomCommandService roomCommandService,
            IRoomQueryService roomQueryService)
        {
            this.temperatureCommandService = temperatureCommandService;
            this.temperatureQueryService = temperatureQueryService;
            this.roomCommandService = roomCommandService;
            this.roomQueryService = roomQueryService;
            Name = "Mutation";

            Field<TemperatureReading>(
                "registerReading",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<RegisterTemperatureReading>> {Name = "temperatureReading"}
                ),
                resolve: context =>
                {
                    var command = context.GetArgument<API.Command.Commands.RegisterTemperatureReading>("temperatureReading");
                    var id = this.temperatureCommandService.RegisterReading(command);
                    return this.temperatureQueryService.GetById(id);
                });

            Field<Room>(
                "registerRoom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<RegisterRoom>> {Name = "room"}
                ),
                resolve: context =>
                {
                    var command = context.GetArgument<API.Command.Commands.RegisterRoom>("room");
                    var id = this.roomCommandService.RegisterRoom(command);
                    return this.roomQueryService.GetById(id);
                });
    }
  }
}