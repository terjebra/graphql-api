using GraphQL.Types;

namespace API.GraphQL.Types {
  public class TemperatureReading : ObjectGraphType<API.Domain.TemperatureReading> {
    
    public TemperatureReading() {
      Name = Name =this.GetType().Name;
      Field(h => h.Id).Description("The id of the readning.");
      Field(h => h.Temperature).Description("The temperature");
    }
  }
}