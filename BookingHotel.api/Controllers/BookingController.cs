using BookingHotel.api.Application.Request;
using BookingHotel.BLL.Models.Book;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BookingHotel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<BookingModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Book(BookingRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
