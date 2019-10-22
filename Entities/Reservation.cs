using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_MyHotel_MyProj.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }
        public int GuestId { get; set; }
        
        [Required]
        public DateTime CheckinDate { get; set; }

        public DateTime CheckoutDate { get; set; }

        public Reservation()
        {

        }

        public Reservation(int roomId, int guestId, DateTime checkinDate, DateTime checkoutDate)
        {
            RoomId = roomId;
            GuestId = guestId;
            CheckinDate = checkinDate;
            CheckoutDate = checkoutDate;
        }
    }

    public class ReservationModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }
        public int GuestId { get; set; }

        [Required]
        public DateTime CheckinDate { get; set; }

        public DateTime CheckoutDate { get; set; }
    }
}
