using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Models;

namespace SE_Backend.Interfaces
{
    public interface IShowRepository
    {
        Task<List<Show>> GetAllAsync();
        Task<Show?> GetByIdAsync(string id);
        Task<Show> CreateAsync(Show showModel);
    }
}