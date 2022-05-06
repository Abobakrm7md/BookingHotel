using BookingHotel.api.Application.Request;
using FluentValidation;

namespace BookingHotel.api.Application.Validations.RoomValidator
{
    public class RoomRequestValidation : AbstractValidator<RoomRequest>
    {
        public RoomRequestValidation()
        {
            RuleFor(x=>x.HotelId).NotEmpty().NotEmpty().GreaterThan(0);
            RuleFor(x => x.BranchId).NotEmpty().NotEmpty().GreaterThan(0);
            RuleFor(x => x.RoomType).NotEmpty().NotEmpty().GreaterThan(0);
        }
    }
}
