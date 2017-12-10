using API.Command.Commands;
using API.Infrastructure;

namespace API.Command
{
  public class CommandService : ICommandService
  {
    private readonly IRepository repository;
    public CommandService(IRepository repository)
    {
      this.repository = repository;
    }

    public string RegisterReading(RegisterTemperatureReading registerRreading)
    {
			var temperatureReading  = new API.Domain.TemperatureReading{
					Id = System.Guid.NewGuid().ToString(),
					Temperature = registerRreading.Temperature
			};
			
			this.repository.Save(temperatureReading);

			return temperatureReading.Id;
		}
  }
}