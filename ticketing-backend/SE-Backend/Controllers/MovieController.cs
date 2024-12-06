using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE_Backend.Data;
using SE_Backend.Dtos.Movie;
using SE_Backend.Mappers;

namespace SE_Backend.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public MovieController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id){
            var movie = _context.Movies.Find(id);

            if(movie == null){
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet("search/{name}")]
        public IActionResult GetByName([FromRoute] string name){
            var movie = _context.Movies.Where(m=> m.Name.ToLower() == name.ToLower()).ToList();

            if(movie == null){
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMovieRequestDto  movieDto ) {
        var movieModel = movieDto.ToMovieFromCreateDTO();
        _context.Movies.Add(movieModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {id = movieModel.Id}, movieModel.ToMovieDto());

        }
    }
}
            
        
    