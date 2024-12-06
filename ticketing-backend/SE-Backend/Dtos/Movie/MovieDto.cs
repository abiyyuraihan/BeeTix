using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Dtos.Movie
{
    public class MovieDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Languange { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string TargetAudience { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
    }
}