using MediatR;

namespace BookingHotel.api.Application.Request
{
    public class RoomRequest 
    {
        public int HotelId { get; set; }
        public int BranchId { get; set; }
        public int RoomType { get; set; }
    }
}
