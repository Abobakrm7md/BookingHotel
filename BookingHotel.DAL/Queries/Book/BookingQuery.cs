using BookingHotel.DAL.Data;
using BookingHotel.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Queries.Book
{
    public class BookingQuery : IBookingQuery
    {
        private readonly BookingHotelContext context;

        public BookingQuery(BookingHotelContext context)
        {
            this.context = context;
        }
        public async Task<Booking> GetBookingByUserId(string UserId)
        {
            return await context.Bookings.FirstOrDefaultAsync(x => x.UserId == UserId);
        }
    }
}
