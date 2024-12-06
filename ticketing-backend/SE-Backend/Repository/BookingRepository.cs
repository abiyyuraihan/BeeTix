using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SE_Backend.Data;
using SE_Backend.Interfaces;
using SE_Backend.Models;

namespace SE_Backend.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDBContext _context;
        public BookingRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Booking.ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(string id)
        {
            return await _context.Booking.Include(c => c.Tickets).FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}