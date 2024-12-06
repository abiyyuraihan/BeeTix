using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE_Backend.Data;
using SE_Backend.Dtos.Booking;
using SE_Backend.Interfaces;
using SE_Backend.Mappers;
using SE_Backend.Models;

namespace SE_Backend.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBookingRepository _bookingRepo;
        public BookingController(ApplicationDBContext context, IBookingRepository bookingRepo)
        {
            _context = context;
            _bookingRepo = bookingRepo;
        }
        [HttpGet]
         public async Task<IActionResult> GetAll(){
            var bookings = await _bookingRepo.GetAllAsync();
            var bookingDto = bookings.Select(t => t.ToBookingDto());
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id){
            var booking = await _bookingRepo.GetByIdAsync(id);

            if(booking == null){
                return NotFound();
            }

            return Ok(booking.ToBookingDto());
        }

        [HttpGet("/booking-history/{id}")]
        public IActionResult GetBookingHistory([FromRoute] string id){
            var booking = _context.Booking.Where(x => x.UserId == id).ToList().Select(b => b.ToBookingDto());

            if (!booking.Any())
            {
                return NotFound("No booking history found for the given user.");
            }

            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookingDto bookingDto)
        {

            var bookingData = new Booking
            {
                NumberOfTickets = bookingDto.NumberOfTickets,
                TotalCost = bookingDto.TotalCost,
                UserId = bookingDto.UserId,
                ShowId = bookingDto.ShowId
            };
            _context.Booking.Add(bookingData);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}