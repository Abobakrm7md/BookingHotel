using BookingHotel.BLL.Models;
using BookingHotel.BLL.Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.BLL.Intrefaces
{
    public interface IHotelService
    {
        Task<List<HotelModel>> GetHotels();
        Task<List<BranchModel>> GetBranches(int HotelId);
    }
}
