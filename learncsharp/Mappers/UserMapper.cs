using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Dtos.User;
using learnteddy.Models;

namespace learnteddy.Mappers
{
    public static class UserMapper
    {
        public static UserDto UserToDto(this User user){

            return new UserDto{
                Id = user.Id,
                FullName = user.FullName,
                Username = user.Username,
                Avatar = user.Avatar,
                Wallet = user.Wallet
            };
        }

        public static User RequestDtoToModel(this UserRequestDto requestDto){
            return new User{
                FullName = requestDto.FullName,
                Username = requestDto.Username,
                Avatar = requestDto.Avatar,
                Wallet = requestDto.Wallet
            };
        }
    }
}