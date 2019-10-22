using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQl_MyHotel_MyProj.Entities;
using GraphQl_MyHotel_MyProj.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GraphQl_MyHotel_MyProj.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : Controller
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationsController(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet("[action]")]
        public async Task<List<ReservationModel>> List()
        {
            return await _reservationRepository.GetAll<ReservationModel>();
        }
    }
}