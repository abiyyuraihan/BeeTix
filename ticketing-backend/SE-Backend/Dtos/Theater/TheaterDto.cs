using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Dtos.Screen;

namespace SE_Backend.Dtos.Theater
{
    public class TheaterDto
    {
        public string Id { get; set; } = string.Empty;
        public string TheaterName { get; set; } = string.Empty;
        public int NumberOfScreens { get; set; }
        public string Area { get; set; } = string.Empty;
        public List<ScreenDto> Screens { get; set; } 
    }
}