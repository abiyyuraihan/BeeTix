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
    public class ScreenRepository : IScreenRepository
    {
        private readonly ApplicationDBContext _context;
        public ScreenRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Screen> CreateAsync(Screen screenModel)
        {
            await _context.Screen.AddAsync(screenModel);
            await _context.SaveChangesAsync();
            return screenModel;
        }

        public async Task<List<Screen>> GetAllAsync()
        {
            return await _context.Screen.ToListAsync();
        }

        public async Task<Screen> GetByIdAsync(string id)
        {
            return await _context.Screen.Include(c => c.Shows).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> ScreenExists(string id)
        {
            return _context.Screen.AnyAsync(i => i.Id == id);
        }
    }
}