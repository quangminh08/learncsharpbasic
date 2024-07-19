using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Dtos.Group;
using learnteddy.Models;

namespace learnteddy.Mappers
{
    public static class GroupMapper
    {
        public static GroupDto GroupToDto(this Group group){

            return new GroupDto{
                Id = group.Id,
                Name = group.Name,
                Avatar = group.Avatar,
            };
        }

        public static Group RequestDtoToModel(this GroupRequestDto requestDto){
            return new Group{
                Name = requestDto.Name!,
                Avatar = requestDto.Avatar!
            };
        }
    }
}