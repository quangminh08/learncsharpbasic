using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Dtos.Message;
using learnteddy.Models;

namespace learnteddy.Mappers
{
    public static class MessageMapper
    {

        public static MessageDto MessageToDto(this Message model){
            return new MessageDto{
                Id = model.Id,
                SenderId = model.SenderId,
                Content = model.Content,
                CreateDate = model.CreateDate
            };
        }

        public static Message RequestDtoToMessage(this MessageRequestDto requestDto){
            return new Message{
                SenderId = requestDto.SenderId,
                Content = requestDto.Content,
                CreateDate = requestDto.CreateDate
            };
        }
    }
}