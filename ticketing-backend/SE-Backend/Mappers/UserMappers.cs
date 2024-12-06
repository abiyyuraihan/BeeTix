using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Dtos.User;
using SE_Backend.Models;

namespace SE_Backend.Mappers
{
    public static class UserMappers
    {

        public static UserDto ToUserDto(this User user){
            return new UserDto{
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age,
                Password = user.Password,
            };
        }
        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto){
            return new User{
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Age = userDto.Age,
                Password = userDto.Password,
            };
        }
    }
}