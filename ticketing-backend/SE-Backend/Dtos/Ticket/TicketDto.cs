using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Dtos.Ticket
{
    public class TicketDto
    {
        public string Id { get; set; } = string.Empty;
        public string? BookingId { get; set; }
        public string Class { get; set; } = string.Empty ;
        public int price { get; set; }
    }
}