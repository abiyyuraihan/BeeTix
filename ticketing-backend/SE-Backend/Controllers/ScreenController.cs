using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE_Backend.Data;
using SE_Backend.Dtos.Screen;
using SE_Backend.Interfaces;
using SE_Backend.Mappers;
using SE_Backend.Models;

namespace SE_Backend.Controllers
{
    [Route("api/screen")]
    [ApiController]
    public class ScreenController : ControllerBase
    {
        private readonly IScreenRepository _context;
        private readonly ITheaterRepository _theaterRepo;
        private readonly ApplicationDBContext _post;
        public ScreenController(IScreenRepository context, ITheaterRepository theaterRepo, ApplicationDBContext post)
        {
            _context = context;
            _theaterRepo = theaterRepo;
            _post = post;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var screens = await _context.GetAllAsync();
            var screenDto = screens.Select(s => s.ToScreenDto());
            return Ok(screenDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id){
            var screen = await _context.GetByIdAsync(id);

            if(screen == null){
                return NotFound();
            }

            return Ok(screen.ToScreenDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateScreenDto screenDto)
        {
            // if(!await _theaterRepo.TheaterExists(theaterId)){
            //     return BadRequest("Theater does not exist");
            // }
            var isTheaterExist = await _post.Theater.Where(x => x.Id == screenDto.TheaterId).AnyAsync();
            var screenData = new Screen
            {
                NumberOfGoldSeats = screenDto.NumberOfGoldSeats,
                NumberOfSilverSeats = screenDto.NumberOfSilverSeats,
                TheaterId = screenDto.TheaterId
            };
            _post.Screen.Add(screenData);
            await _post.SaveChangesAsync();
            return Ok();
        }

    }
}