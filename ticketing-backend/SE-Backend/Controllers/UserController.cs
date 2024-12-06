using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE_Backend.Data;
using SE_Backend.Dtos.User;
using SE_Backend.Mappers;

namespace SE_Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.User.ToList().Select(u => u.ToUserDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var user = _context.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequestDto userDto)
        {
            var user = userDto.ToUserFromCreateDTO();
            _context.User.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user.ToUserDto());
        }

        [HttpPut]
        [Route("profile/{id}")]
        public IActionResult UpdateProfile([FromRoute] string id, [FromBody] UpdateProfileRequestDto updateDto)
        {
            var user = _context.User.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            user.Password = updateDto.Password;
            user.FirstName = updateDto.FirstName;
            user.LastName = updateDto.LastName;
            user.Email = updateDto.Email;
            user.Age = updateDto.Age;
            user.PhoneNumber = updateDto.PhoneNumber;

            _context.SaveChanges();

            return Ok(user.ToUserDto());
        }

        [HttpPut]
        [Route("forgot-password/{email}")]
        public IActionResult UpdatePassword([FromRoute] string email, [FromBody] UpdatePasswordRequestDto updateDto)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return NotFound();
            }
            user.Password = updateDto.Password;

            _context.SaveChanges();

            return Ok(user.ToUserDto());
        }

        [HttpPost("login")]
        public IActionResult login(LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest("Email and Password must be provided.");
            }

            // Search for the user with matching email and password
            var user = _context.User
                .SingleOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Kembalikan response
            return Ok(new
            {
                Message = "Login berhasil.",
                User = new NewUserDto
                {
                    email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    PhoneNumber = user.PhoneNumber
                }
            });
        }
    }
}