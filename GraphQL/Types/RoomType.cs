using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQl_MyHotel_MyProj.Entities;

namespace GraphQl_MyHotel_MyProj.GraphQL.Types
{
    public class RoomType : ObjectGraphType<Room>
    {
        public RoomType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Number);
            Field(x => x.AllowedSmoking);
            Field<RoomStatusType>(nameof(Room.Status));
        }
    }
}
