using GraphQL.Types;

namespace API.GraphQL.Types {

  public class Room : ObjectGraphType<API.Domain.Room> {
    
    public Room() {
      Name = Name =this.GetType().Name;
      Field(h => h.Id).Description("The id of the room.");
      Field(h => h.Name).Description("The name of the room");
    }
  }
}