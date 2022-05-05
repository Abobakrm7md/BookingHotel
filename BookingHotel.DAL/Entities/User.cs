using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Entities
{
    public class User : IdentityUser
    {
        public long NationalId { get; set; }
    }
}
