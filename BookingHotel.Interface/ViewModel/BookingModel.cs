using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Interface.ViewModel
{
    public class BookingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "NationalId")]
        public long NationalId { get; set; }
        [Required]
        [Display(Name ="Hotel")]
        public int HotelId { get; set; }
        public List<HotelModel> HotelModel { get; set; }
        [Required]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Required]
        [Display(Name = "Room Type")]
        public int RoomType { get; set; }
        [Required]
        [Display(Name = "Room")]
        public List<int> RoomId { get; set; }
        [Required]
        [Display(Name = "CheckIn Date")]
        public DateTime CheckIn { get; set; }
        [Display(Name = "CheckOut Date")]

        public DateTime CheckOut { get; set; }
    }
}
