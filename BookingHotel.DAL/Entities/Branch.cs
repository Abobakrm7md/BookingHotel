using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HotelId { get; set; }
        public Hotel  Hotel { get; set; }
    }
}
