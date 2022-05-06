using BookingHotel.BLL.Intrefaces;
using BookingHotel.BLL.Models;
using BookingHotel.BLL.Models.Hotel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BookingHotel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<HotelModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Hotels()
        {
            var result = await hotelService.GetHotels();
            return Ok(result);
        }
        [HttpGet("{HotelId}/branches")]
        [ProducesResponseType(typeof(List<HotelModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Branches([FromRoute]int HotelId)
        {
            var result = await hotelService.GetBranches(HotelId);
            return Ok(result);
        }
    }
}
