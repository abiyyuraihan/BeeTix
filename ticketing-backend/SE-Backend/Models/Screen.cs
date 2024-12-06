using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Models
{
    public class Screen
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int NumberOfGoldSeats { get; set; }
        public int NumberOfSilverSeats { get; set; }
        public string? TheaterId { get; set; }
        public Theater? Theater { get; set; }
        public List<Show> Shows { get; set; } = new List<Show>();
    }
}