using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQl_MyHotel_MyProj.Entities;

namespace GraphQl_MyHotel_MyProj.GraphQL.Types
{
    public class ReservationType : ObjectGraphType<Reservation>
    {
        public ReservationType()
        {
            Field(x => x.Id);
            Field(x => x.CheckinDate);
            Field(x => x.CheckoutDate);
            Field<GuestType>(nameof(Reservation.Guest));
            Field<RoomType>(nameof(Reservation.Room));
        }
    }
}
