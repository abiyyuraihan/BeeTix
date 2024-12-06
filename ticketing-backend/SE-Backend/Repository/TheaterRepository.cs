using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SE_Backend.Data;
using SE_Backend.Dtos.Theater;
using SE_Backend.Interfaces;
using SE_Backend.Models;

namespace SE_Backend.Repository
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly ApplicationDBContext _context;
        public TheaterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Theater> CreateAsync(Theater theaterModel)
        {
            await _context.Theater.AddAsync(theaterModel);
            await _context.SaveChangesAsync();
            return theaterModel;
        }

        public async Task<List<Theater>> GetAllAsync()
        {
            return await _context.Theater.Include(c => c.Screens).ToListAsync();
        }

        public async Task<Theater?> GetByIdAsync(string id)
        {
           return await _context.Theater.Include(c => c.Screens).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> TheaterExists(string id)
        {
            return _context.Theater.AnyAsync(i => i.Id == id);
        }
    }
    }
