using API.Command.Commands;

namespace API.Command
{
  public interface ITemperatureCommandService
  {
      string RegisterReading(RegisterTemperatureReading registerReading); 
  }
}