using API.Command.Commands;
using API.Infrastructure;

namespace API.Command
{
  public class RoomCommandService : IRoomCommandService
  {
    private readonly IRepository<Domain.Room> repository;
    public RoomCommandService(IRepository<Domain.Room>repository)
    {
      this.repository = repository;
    }

    public string RegisterRoom(RegisterRoom registerRoom)
    {
      var room  = new API.Domain.Room{
        Id = System.Guid.NewGuid().ToString(),
        Name = registerRoom.Name
      };
        
      this.repository.Save(room);

      return room.Id;  
    }
  }
}