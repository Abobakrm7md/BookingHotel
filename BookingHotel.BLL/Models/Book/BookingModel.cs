using BookingHotel.BLL.Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.BLL.Models.Book
{
    public class BookingModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public HotelModel Hotel { get; set; }
        public List<int> Rooms { get; set; }
        public double Cost { get; set; }
        public string Token { get; set; }
    }
}
