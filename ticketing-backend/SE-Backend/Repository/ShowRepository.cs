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
    public class ShowRepository : IShowRepository
    {
        private readonly ApplicationDBContext _context;
        public ShowRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<Show> CreateAsync(Show showModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Show>> GetAllAsync()
        {
            return await _context.Show
            .Include(c => c.Screen)
            .Include(c => c.Movie)
            .ToListAsync();
        }

        public async Task<Show?> GetByIdAsync(string id)
        {
            return await _context.Show
            .Include(c => c.Screen)
            .Include(c => c.Movie)
            .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}