using BookingHotel.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Queries.Room
{
    public class RoomQuery : IRoomQuery
    {
        private readonly BookingHotelContext context;

        public RoomQuery(BookingHotelContext context)
        {
            this.context = context;
        }
        public async Task<List<Entities.Room>> GetRoomsByBookingId(int BookingId, bool IgnoreQueryFilter)
        {
            if (IgnoreQueryFilter)
                return await context.Rooms.IgnoreQueryFilters().Where(r => r.BookingId == BookingId).ToListAsync();

            return await context.Rooms.Where(r => r.BookingId == BookingId).ToListAsync();
        }

        public async Task<List<Entities.Room>> GetRoomsById(List<int> RoomsId, bool IgnoreQueryFilter)
        {
            if(IgnoreQueryFilter)
                return await context.Rooms.IgnoreQueryFilters().Where(r => RoomsId.Contains(r.Id)).ToListAsync();
            return await context.Rooms.Where(r => RoomsId.Contains(r.Id)).ToListAsync();
        }
    }
}
