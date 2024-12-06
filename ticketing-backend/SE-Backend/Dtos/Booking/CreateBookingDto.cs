using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Dtos.Booking
{
    public class CreateBookingDto
    {

        public int NumberOfTickets { get; set; }
        public int TotalCost { get; set; }
        public string? UserId { get; set; }
        public string? ShowId { get; set; }
    }
}