using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Dtos.Theater;
using SE_Backend.Models;

namespace SE_Backend.Interfaces
{
    public interface ITheaterRepository
    {
        Task<List<Theater>> GetAllAsync();
        Task<Theater?> GetByIdAsync(string id);
        Task<Theater> CreateAsync(Theater theaterModel);
        Task<bool> TheaterExists(string id);

    }
}