using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Dtos.Ticket
{
    public class CreateTicketDto
    {

        public string? BookingId { get; set; }
        public string Class { get; set; } = string.Empty ;
        public int price { get; set; }
    }
}