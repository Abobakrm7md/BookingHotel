using BookingHotel.Interface.Configurations;
using BookingHotel.Interface.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookingHotel.Interface.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Book()
        {
            var hotel = CreateClient.SendRestPostRequest("api/hotel", RestSharp.Method.GET ,"", null);
            var content = hotel.Content;
            var hotels = JsonConvert.DeserializeObject<List<HotelModel>>(content);
            BookingModel model = new BookingModel() { HotelModel = hotels };
            return View(hotels);
        }
    }
}
