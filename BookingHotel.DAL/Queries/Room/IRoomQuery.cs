using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Queries.Room
{
    public interface IRoomQuery
    {
        Task<List<BookingHotel.DAL.Entities.Room>> GetRoomsByBookingId(int BookingId, bool IgnoreQueryFilter);
        Task<List<BookingHotel.DAL.Entities.Room>> GetRoomsById(List<int> RoomsId, bool IgnoreQueryFilter);
    }
}
