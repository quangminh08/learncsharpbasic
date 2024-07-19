using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Data;
using learnteddy.Dtos.Message;
using learnteddy.Models;
using learnteddy.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace learnteddy.Repositories
{
    public class MessageRepository : IMessageRepository
    
    {
        private readonly ApplicationDBContext _DBContext;
        public MessageRepository(ApplicationDBContext applicationDBContext){
            _DBContext = applicationDBContext;
        }

        public async Task<Message> CreateAsync(Message model)
        {
            await _DBContext.messages.AddAsync(model);
            await _DBContext.SaveChangesAsync(); 
            return model;
        }

         public async Task<Message?> DeleteAsync(int id)
        {
            var model = await _DBContext.messages.FirstOrDefaultAsync(m => m.Id == id);
            if (model == null){
                return null;
            }
            // Không thêm await vì Remove không phải là một chức năng không đồng bộ
            _DBContext.messages.Remove(model);
            await _DBContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<Message>> GetAllAsync()
        {
           var models = await _DBContext.messages.ToListAsync();
           return models;
        }

        public async Task<Message?> GetByIdAsync(int id)
        {
            var model = await _DBContext.messages.FindAsync(id);
            return model;
        }

        // public Task<Message?> GetMessageByUserId(int userId)
        // {
            
        // }

        public async Task<Message?> UpdateAsync(int id, MessageRequestDto messageRequestDto)
        {
            var model = await _DBContext.messages.FindAsync(id);
            if(model == null){
                return null;
            }
            model.Content = messageRequestDto.Content;
            await _DBContext.SaveChangesAsync();
            return model;
        }
    }
}