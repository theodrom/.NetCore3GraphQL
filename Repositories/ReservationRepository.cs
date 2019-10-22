using AutoMapper;
using AutoMapper.QueryableExtensions;
using GraphQl_MyHotel_MyProj.Entities;
using GraphQl_MyHotel_MyProj.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_MyHotel_MyProj.Repositories
{
    public class ReservationRepository
    {
        private readonly MyHotelDbContext _myHotelDbContext;
        private readonly IMapper _mapper;

        public ReservationRepository(MyHotelDbContext myHotelDbContext, IMapper mapper)
        {
            _myHotelDbContext = myHotelDbContext;
            _mapper = mapper;
        }

        public async Task<List<T>> GetAll<T>()
        {
            return await GetQuery().ProjectTo<T>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _myHotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest)
                .ToListAsync();
        }

        public Reservation Get(int id)
        {
            return GetQuery().Single(x => x.Id == id);
        }

        public IIncludableQueryable<Reservation, Guest> GetQuery()
        {
            return _myHotelDbContext
                 .Reservations
                 .Include(x => x.Room)
                 .Include(x => x.Guest);
        }

    }
}
