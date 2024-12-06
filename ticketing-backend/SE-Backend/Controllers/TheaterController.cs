using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE_Backend.Data;
using SE_Backend.Dtos.Theater;
using SE_Backend.Interfaces;
using SE_Backend.Mappers;

namespace SE_Backend.Controllers
{
    [Route("api/theater")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ITheaterRepository _theaterRepo;
        public TheaterController(ApplicationDBContext context, ITheaterRepository theaterRepo)
        {
            _theaterRepo = theaterRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var theaters = await _theaterRepo.GetAllAsync();
            var theaterDto = theaters.Select(t => t.ToTheaterDto());
            return Ok(theaters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id){
            var theater = await _theaterRepo.GetByIdAsync(id);

            if(theater == null){
                return NotFound();
            }

            return Ok(theater.ToTheaterDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTheaterRequestDto  theaterDto ) {
            var theaterModel = theaterDto.ToTheaterFromCreateDTO();
            await _theaterRepo.CreateAsync(theaterModel);
            return CreatedAtAction(nameof(GetById), new {id = theaterModel.Id}, theaterModel.ToTheaterDto());
        }
    }
}