using BookingHotel.Interface.Configurations;
using BookingHotel.Interface.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingHotel.Interface.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Book()
        {
            var hotel = await CreateClient.SendRestPostRequest("api/hotel", RestSharp.Method.Get ,"", null);
            var content = hotel.Content;
            var hotels = JsonConvert.DeserializeObject<List<HotelModel>>(content);
            BookingModel model = new BookingModel() { HotelModel = hotels };
            return View(hotels);
        }
    }
}
