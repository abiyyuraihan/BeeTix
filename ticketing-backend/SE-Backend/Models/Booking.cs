using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Models
{
    public class Booking
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int NumberOfTickets { get; set; }
        public int TotalCost { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public string? ShowId { get; set; }
        public Show? Show { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}