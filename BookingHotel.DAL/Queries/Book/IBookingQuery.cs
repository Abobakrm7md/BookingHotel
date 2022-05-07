using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Queries.Book
{
    public interface IBookingQuery
    {
        Task<BookingHotel.DAL.Entities.Booking> GetBookingByUserId(string UserId);
    }
}
