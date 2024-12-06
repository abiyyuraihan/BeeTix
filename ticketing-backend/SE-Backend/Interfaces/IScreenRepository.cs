using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Models;
namespace SE_Backend.Interfaces

{
    public interface IScreenRepository
    {
        Task<List<Screen>> GetAllAsync();
        Task<Screen?> GetByIdAsync(string id);
        Task<Screen> CreateAsync(Screen screenModel);
        Task<bool> ScreenExists(string id);
    }
}