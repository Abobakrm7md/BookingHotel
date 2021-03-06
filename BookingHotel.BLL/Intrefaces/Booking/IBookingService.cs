using BookingHotel.BLL.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.BLL.Intrefaces.Booking
{
    public interface IBookingService 
    {
        Task<BookingModel> Book(BookingArguments arguments);
        Task CancelBooking(int BookingId);
       Task UpdateBooking(int Id , int HotelId, int BranchId, List<int> RoomsId, DateTime CheckIn, DateTime CheckOut);
    }
}
