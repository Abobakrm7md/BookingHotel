using System.Collections.Generic;

namespace BookingHotel.Interface.ViewModel
{
    public class BookingModel
    {
        public int HotelId { get; set; }
        public List<HotelModel> HotelModel { get; set; }
        public int BranchId { get; set; }
    }
}
