using BookingHotel.api.Application.Request;
using BookingHotel.BLL.Intrefaces;
using BookingHotel.BLL.Models.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BookingHotel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            this._roomService = roomService;
        }

        [HttpGet("type")]
        [ProducesResponseType(typeof(List<RoomTypeModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RoomsType()
        {
            var result = await _roomService.GetRoomTypes();
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<RoomModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Rooms(RoomRequest request)
        {
            var result = await _roomService.GetRooms(request.HotelId, request.BranchId , request.RoomType);
            return Ok(result);
        }
    }
}
