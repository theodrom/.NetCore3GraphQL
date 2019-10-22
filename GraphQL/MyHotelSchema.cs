using GraphQL.Types;
using GraphQL;
using GraphQL.Http;
using System;
using GraphQL.Utilities;

namespace GraphQl_MyHotel_MyProj.GraphQL
{
    public class MyHotelSchema : Schema
    {
        public MyHotelSchema(IServiceProvider resolver) 
            : base(resolver)
        {
            Query = resolver.GetRequiredService<ReservationQuery>();
        }
    }
}

// https://github.com/graphql-dotnet/graphql-dotnet/blob/master/docs2/site/docs/getting-started/dependency-injection.md