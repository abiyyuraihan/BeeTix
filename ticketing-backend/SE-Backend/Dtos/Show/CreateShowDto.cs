using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Dtos.Show
{
    public class CreateShowDto
    {
        public DateTime ShowDateAndTime { get; set; }
        public int SeatsRemainingGold { get; set; }
        public int SeatsRemainingSilver { get; set; }
        public string? ScreenId { get; set; }
        public string? MovieId { get; set; }
    }
}