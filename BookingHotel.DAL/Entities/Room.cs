using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int BranchId { get; set; }
        public int Type { get; set; }
        public int? BookingId { get; set; }
        public Hotel  Hotel { get; set; }
        public Branch Branch { get; set; }
        public LookUp  LookUp { get; set; }
        public Booking  Booking { get; set; }
    }
}
