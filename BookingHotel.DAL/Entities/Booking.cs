using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string UserId { get; set; }
        public User  User { get; set; }
    }
}
