using GraphQL;
using GraphQL.Types;
using GraphQl_MyHotel_MyProj.Entities;
using GraphQl_MyHotel_MyProj.GraphQL.Types;
using GraphQl_MyHotel_MyProj.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraphQl_MyHotel_MyProj.GraphQL
{
    public class ReservationQuery : ObjectGraphType
    {

        public ReservationQuery(ReservationRepository reservationRepository)
        {
            /*Version: 1 get all*/
            //Field<ListGraphType<ReservationType>>("reservations",
            //    resolve: context => reservationRepository.GetQuery());

            /*Version: 2 filtering*/
            Field<ListGraphType<ReservationType>>("reservations",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType>
                    {
                        Name = "id"
                    },
                    new QueryArgument<DateGraphType>
                    {
                        Name = "checkinDate"
                    },
                    new QueryArgument<DateGraphType>
                    {
                        Name = "checkoutDate"
                    },
                    new QueryArgument<BooleanGraphType>
                    {
                        Name = "roomAllowedSmoking"
                    },
                    new QueryArgument<RoomStatusType>
                    {
                        Name = "roomStatus"
                    }
                }),
                resolve: context =>
                {
                    var query = reservationRepository.GetQuery();

                    //var user = (ClaimsPrincipal)context.UserContext;
                    //var isUserAuthenticated = ((ClaimsIdentity)user.Identity).IsAuthenticated;

                    var reservationId = context.GetArgument<int?>("id");
                    if (reservationId.HasValue)
                    {
                        if (reservationId.Value <= 0)
                        {
                            context.Errors.Add(new ExecutionError("reservationId must be greater than zero!"));
                            return new List<Reservation>();
                        }

                        return query.Where(r => r.Id == reservationId.Value);
                    }

                    var checkinDate = context.GetArgument<DateTime?>("checkinDate");
                    if (checkinDate.HasValue)
                    {
                        return query.Where(r => r.CheckinDate.Date == checkinDate.Value.Date);
                    }

                    var checkoutDate = context.GetArgument<DateTime?>("checkoutDate");
                    if (checkoutDate.HasValue)
                    {
                        return query.Where(r => r.CheckoutDate.Date >= checkoutDate.Value.Date);
                    }

                    var allowedSmoking = context.GetArgument<bool?>("roomAllowedSmoking");
                    if (allowedSmoking.HasValue)
                    {
                        return query.Where(r => r.Room.AllowedSmoking == allowedSmoking.Value);
                    }

                    var roomStatus = context.GetArgument<RoomStatus?>("roomStatus");
                    if (roomStatus.HasValue)
                    {
                        return query.Where(r => r.Room.Status == roomStatus.Value);
                    }

                    return query.ToList();
                }
            );

        }
    }
}
