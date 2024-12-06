using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Models
{
    public class Ticket
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? BookingId { get; set; }
        public Booking? Booking { get; set; }
        public string Class { get; set; } = string.Empty ;
        public int price { get; set; }
    }
}