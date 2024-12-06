using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Dtos.Show;
using SE_Backend.Models;

namespace SE_Backend.Mappers
{
    public static class ShowMappers
    {
        public static ShowDto ToShowDto(this Show showModel)
        {
            return new ShowDto
            {
                Id = showModel.Id,
                MovieId = showModel.MovieId,
                ScreenId = showModel.ScreenId,
                ShowDateAndTime = showModel.ShowDateAndTime
            };
        }

        public static Show ToShowFromCreate(this CreateShowDto showDto, string movieId, string screenId)
        {
            return new Show
            {
                MovieId = movieId,
                ScreenId = screenId,
                ShowDateAndTime = showDto.ShowDateAndTime
            };
        }
    }
}