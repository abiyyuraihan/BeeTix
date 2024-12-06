using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Dtos.Screen;
using SE_Backend.Models;

namespace SE_Backend.Mappers
{
    public static class ScreenMappers
    {
        public static ScreenDto ToScreenDto(this Screen screenModel){
            return new ScreenDto{
                Id = screenModel.Id,
                NumberOfGoldSeats = screenModel.NumberOfGoldSeats,
                NumberOfSilverSeats = screenModel.NumberOfSilverSeats,
                TheaterId = screenModel.TheaterId,
            };
        }

        public static Screen ToScreenFromCreate(this CreateScreenDto screenDto, string theaterId){
            return new Screen
            {
                NumberOfGoldSeats = screenDto.NumberOfGoldSeats,
                NumberOfSilverSeats = screenDto.NumberOfSilverSeats,
                TheaterId = theaterId,
            };
        }
    }
}