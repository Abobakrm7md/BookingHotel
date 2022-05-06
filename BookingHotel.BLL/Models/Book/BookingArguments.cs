using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.BLL.Models.Book
{
    public class BookingArguments
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public long NationalId { get; set; }
        public int HotelId { get; set; }
        public int BranchId { get; set; }
        public List<int> RoomsId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
