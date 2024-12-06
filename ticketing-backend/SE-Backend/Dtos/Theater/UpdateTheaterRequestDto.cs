using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Dtos.Theater
{
    public class UpdateTheaterRequestDto
    {
        public string TheaterName { get; set; } = string.Empty;
        public int NumberOfScreens { get; set; }
        public string Area { get; set; } = string.Empty; 
    }
}