using GraphQL.Types;

namespace API.GraphQL.Types {
  public class RegisterRoom : InputObjectGraphType{
    
    public RegisterRoom() {
      Name =this.GetType().Name;
      Field<NonNullGraphType<StringGraphType>>("name");
    }
  }
}