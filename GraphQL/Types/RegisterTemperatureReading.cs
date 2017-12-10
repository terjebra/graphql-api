using GraphQL.Types;

namespace API.GraphQL.Types {
  public class RegisterTemperatureReading : InputObjectGraphType{
    
    public RegisterTemperatureReading() {
      Name =this.GetType().Name;
      Field<NonNullGraphType<DecimalGraphType>>("temperature");
    }
  }
}