using API.Command.Commands;

namespace API.Command
{
  public interface ICommandService
  {
      string RegisterReading(RegisterTemperatureReading registerRreading); 
  }
}