using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SE_Backend.Models;

namespace SE_Backend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Theater> Theater { get; set; }
        public DbSet<Screen> Screen { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Show> Show { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<User> User { get; set; }
        
    }
}