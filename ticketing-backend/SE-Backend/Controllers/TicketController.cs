using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE_Backend.Data;
using SE_Backend.Dtos.Ticket;
using SE_Backend.Models;

namespace SE_Backend.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TicketController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var tickets = _context.Ticket.ToList();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var ticket = _context.Ticket.Find(id);

            if(ticket == null){
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketDto ticketDto)
        {

            var ticketData = new Ticket
            {
                Class = ticketDto.Class,
                price = ticketDto.price,
                BookingId = ticketDto.BookingId
            };
            _context.Ticket.Add(ticketData);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}