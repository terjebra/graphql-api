using System;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class GraphQLSettings
    {
        public PathString Path { get; set; } = "/API/graphql";
        public Func<HttpContext, object> BuildUserContext { get; set; }
    }
}