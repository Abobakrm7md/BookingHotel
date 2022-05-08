using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotel.Interface.ViewModel
{
    public class BookingDetailsModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public HotelModel Hotel { get; set; }
        public List<int> Rooms { get; set; }
        public double Cost { get; set; }
        public string Token { get; set; }
    }
}
