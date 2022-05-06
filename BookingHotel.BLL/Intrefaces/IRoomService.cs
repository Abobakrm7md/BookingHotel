using BookingHotel.BLL.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.BLL.Intrefaces
{
    public interface IRoomService
    {
        Task<List<RoomTypeModel>> GetRoomTypes();
        Task<List<RoomModel>> GetRooms(int HotelId,int BranchId, int RoomType);
    }
}
