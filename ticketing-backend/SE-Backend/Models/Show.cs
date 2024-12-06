using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Models
{
    public class Show
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime ShowDateAndTime { get; set; }
        public int SeatsRemainingGold { get; set; }
        public int SeatsRemainingSilver { get; set; }

        public string? ScreenId { get; set; }
        public Screen? Screen { get; set; }
        public string? MovieId { get; set; }

        public Movie? Movie { get; set; }
    }
}