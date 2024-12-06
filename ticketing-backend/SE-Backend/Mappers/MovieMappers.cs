using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Dtos.Movie;
using SE_Backend.Models;

namespace SE_Backend.Mappers
{
    public static class MovieMappers
    {
        public static MovieDto ToMovieDto(this Movie movieModel){
            return new MovieDto
            {
                Id = movieModel.Id,
                Name = movieModel.Name,
                Languange = movieModel.Languange,
                Genre = movieModel.Genre,
                TargetAudience = movieModel.TargetAudience,
                Synopsis = movieModel.Synopsis,
                PosterUrl = movieModel.PosterUrl,
            };
        }

        public static Movie ToMovieFromCreateDTO(this CreateMovieRequestDto movieDto){
            return new Movie
            {
                Name = movieDto.Name,
                Languange = movieDto.Languange,
                Genre = movieDto.Genre,
                TargetAudience = movieDto.TargetAudience,
                Synopsis = movieDto.Synopsis,
                PosterUrl = movieDto.PosterUrl,
            };
        }
    }
}