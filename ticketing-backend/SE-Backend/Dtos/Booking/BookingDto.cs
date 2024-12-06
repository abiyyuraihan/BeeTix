using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Dtos.Ticket;
using SE_Backend.Models;

namespace SE_Backend.Dtos.Booking
{
    public class BookingDto
    {
        public string Id { get; set; } = string.Empty;
        public int NumberOfTickets { get; set; }
        public int TotalCost { get; set; }
        public string? UserId { get; set; }
        public string? ShowId { get; set; }
        public List<TicketDto> Tickets { get; set; } 
    }
}