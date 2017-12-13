using API.Command.Commands;
using API.Infrastructure;

namespace API.Command
{
  public class TemperatureCommandService : ITemperatureCommandService
  {
    private readonly IRepository<Domain.TemperatureReading> repository;
    public TemperatureCommandService(IRepository<Domain.TemperatureReading>repository)
    {
      this.repository = repository;
    }

    public string RegisterReading(RegisterTemperatureReading registerReading)
    {
			var temperatureReading  = new API.Domain.TemperatureReading{
        Id = System.Guid.NewGuid().ToString(),
        Temperature = registerReading.Temperature
			};
			
			this.repository.Save(temperatureReading);

			return temperatureReading.Id;
		}
  }
}