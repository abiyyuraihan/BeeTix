using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Dtos.Screen
{
    public class CreateScreenDto
    {
        public int NumberOfGoldSeats { get; set; }
        public int NumberOfSilverSeats { get; set; }
        public string? TheaterId { get; set; } 
    }
}