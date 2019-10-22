using AutoMapper;
using GraphQl_MyHotel_MyProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_MyHotel_MyProj.Mapper
{
    public class ReservationsMappingProfile : Profile
    {
        public ReservationsMappingProfile()
        {
            CreateMap<Guest, GuestModel>().ReverseMap();
            //CreateMap<GuestModel, Guest>();

            CreateMap<Room, RoomModel>().ReverseMap();
            //CreateMap<RoomModel, Room>();

            CreateMap<Reservation, ReservationModel>().ReverseMap();
            //CreateMap<ReservationModel, Reservation >();
        }
    }
}

// https://stackoverflow.com/questions/40275195/how-to-set-up-automapper-in-asp-net-core