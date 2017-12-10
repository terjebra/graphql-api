using GraphQL;
using GraphQL.Types;

namespace API.GraphQL
{
    public class APISchema : Schema
    {
        public APISchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<Query>();
            Mutation = resolver.Resolve<Mutation>();
        }
    }
}