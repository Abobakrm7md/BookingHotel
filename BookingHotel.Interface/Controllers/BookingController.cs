using BookingHotel.Interface.Configurations;
using BookingHotel.Interface.Models;
using BookingHotel.Interface.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BookingHotel.Interface.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Book()
        {
            var hotel = await CreateClient.SendRestPostRequest("api/hotel", RestSharp.Method.Get, "", null);
            var content = hotel.Content;
            var hotels = JsonConvert.DeserializeObject<List<HotelModel>>(content);
            BookingModel model = new BookingModel() { HotelModel = hotels };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Book(BookingModel model)
        {
            BookingArguments booking = new BookingArguments
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                NationalId = model.NationalId,
                HotelId = model.HotelId,
                BranchId = model.BranchId,
                RoomsId = model.RoomId,
                CheckIn = model.CheckIn,
                CheckOut = model.CheckOut
            };
            if (ModelState.IsValid)
            {
               // string body = JsonConvert.SerializeObject(booking, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                string updateUserUrl = $"api/booking";
                var response = await CreateClient.SendRestPostRequest(updateUserUrl,RestSharp.Method.Post , "", booking);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    BookingDetailsModel detailsModel = JsonConvert.DeserializeObject<BookingDetailsModel>(response.Content);
                    return View("Details" , detailsModel);
                }
                return View(model);
            }
            return View(model);
        }
    }
}
