using GraphQL.Types;
using GraphQl_MyHotel_MyProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_MyHotel_MyProj.GraphQL.Types
{
    public class GuestType : ObjectGraphType<Guest>
    {
        public GuestType()
        {
            Field(x => x.Id);
            Field(x => x.Name).Description("The name of the guest");
            Field(x => x.RegisterDate).Description("The date the registration has been made");
        }
    }
}
