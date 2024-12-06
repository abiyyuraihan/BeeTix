using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE_Backend.Data;
using SE_Backend.Dtos.Show;
using SE_Backend.Interfaces;
using SE_Backend.Mappers;
using SE_Backend.Models;

namespace SE_Backend.Controllers
{
    [Route("api/show")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IShowRepository _showRepo;

        public ShowController(ApplicationDBContext context, IShowRepository showRepo)
        {
            _context = context;
            _showRepo = showRepo;
        }

        // [HttpGet]
        // public IActionResult GetAll(){
        //     var shows = _context.Show.ToList();
        //     return Ok(shows);
        // }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shows = await _showRepo.GetAllAsync();
            var showDtos = shows.Select(t => t.ToShowDto());
            return Ok(shows);
        }

        // [HttpGet("{id}")]
        // public IActionResult GetById([FromRoute] int id){
        //     var show = _context.Show.Find(id);

        //     if(show == null){
        //         return NotFound();
        //     }

        //     return Ok(show);
        // }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var show = await _showRepo.GetByIdAsync(id);

            if (show == null)
            {
                return NotFound();
            }

            return Ok(show.ToShowDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShowDto screenDto)
        {

            var showData = new Show
            {
                SeatsRemainingGold = screenDto.SeatsRemainingGold,
                SeatsRemainingSilver = screenDto.SeatsRemainingSilver,
                ScreenId = screenDto.ScreenId,
                MovieId = screenDto.MovieId,
            };
            _context.Show.Add(showData);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}