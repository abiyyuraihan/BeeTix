using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Dtos.Theater;
using SE_Backend.Models;

namespace SE_Backend.Mappers
{
    public static class ThetherMapper
    {
        public static TheaterDto ToTheaterDto(this Theater theaterModel){
            return new TheaterDto
            {
                Id = theaterModel.Id,
                TheaterName = theaterModel.TheaterName,
                NumberOfScreens = theaterModel.NumberOfScreens,
                Area = theaterModel.Area,
                Screens = theaterModel.Screens.Select(c => c.ToScreenDto()).ToList()
            };
        }

        public static Theater ToTheaterFromCreateDTO(this CreateTheaterRequestDto theaterDto){
            return new Theater
            {
                TheaterName = theaterDto.TheaterName,
                NumberOfScreens = theaterDto.NumberOfScreens,
                Area = theaterDto.Area,
            };
        }
    }
}
