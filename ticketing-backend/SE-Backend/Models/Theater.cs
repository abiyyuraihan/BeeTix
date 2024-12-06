using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Backend.Models
{
    public class Theater
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string TheaterName { get; set; } = string.Empty;
        public int NumberOfScreens { get; set; }
        public string Area { get; set; } = string.Empty;
        public List<Screen> Screens { get; set; } = new List<Screen>();
    }
}