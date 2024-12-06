using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Dtos.Screen
{
    public class ScreenDto
    {
        public string Id { get; set; } = string.Empty;
        public int NumberOfGoldSeats { get; set; }
        public int NumberOfSilverSeats { get; set; }
        public string? TheaterId { get; set; }
    }
}