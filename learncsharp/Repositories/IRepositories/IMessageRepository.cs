using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Dtos.Message;
using learnteddy.Models;

namespace learnteddy.Repositories.IRepositories
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAllAsync();

        Task<Message?> GetByIdAsync(int id);

        Task<Message> CreateAsync(Message model);

        Task<Message?> UpdateAsync(int id, MessageRequestDto messageRequestDto);

        Task<Message?> DeleteAsync(int id);

        // Task<Message?> GetMessageByUserId(int userId);
    }
}