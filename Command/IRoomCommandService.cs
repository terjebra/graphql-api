using API.Command.Commands;

namespace API.Command
{
  public interface IRoomCommandService
  {
      string RegisterRoom(RegisterRoom registerRoom); 
  }
}