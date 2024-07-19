using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Data;
using learnteddy.Dtos.User;
using learnteddy.Mappers;
using learnteddy.Models;
using Microsoft.EntityFrameworkCore;

namespace learnteddy.Repositories
{
    public class UserRepository : IUserRepository
    {

        public readonly ApplicationDBContext _DBContext;
        public UserRepository(ApplicationDBContext applicationDBContext)
        {
            _DBContext = applicationDBContext;
        }

        public async Task<User> CreateAsync(User model)
        {
            await _DBContext.users.AddAsync(model);
            await _DBContext.SaveChangesAsync(); 
            return model;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var model = await _DBContext.users.FirstOrDefaultAsync(u => u.Id == id);
            if (model == null){
                return null;
            }
            // Không thêm await vì Remove không phải là một chức năng không đồng bộ
            _DBContext.users.Remove(model);
            await _DBContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var models = await _DBContext.users.ToListAsync();
            return models;
        }

        public async Task<List<User>> SearchAsync(UserFilter searchObj)
        {
            // var models = await _DBContext.users.ToListAsync()
            var models = _DBContext.users.AsQueryable();
            if(!string.IsNullOrWhiteSpace(searchObj.FullName)){
                models = models.Where(u => u.FullName.Contains(searchObj.FullName));
                Console.WriteLine("NNNNNN+++++++ " + searchObj.FullName);
            } 
            if(!string.IsNullOrWhiteSpace(searchObj.Avatar)){
                models = models.Where(u => u.Avatar.Contains(searchObj.Avatar!));
                Console.WriteLine("NNNNNN+++++++ " + searchObj.Avatar);
            }
            if(!string.IsNullOrWhiteSpace(searchObj.SortBy)){
                if(searchObj.SortBy.Equals("FullName", StringComparison.OrdinalIgnoreCase)){
                    models = searchObj.IsDecsending ? models.OrderByDescending(u => u.FullName) : models.OrderBy(u => u.FullName);
                }
            }

            var skipNumber = (searchObj.PageNumber - 1) * searchObj.PageSize;
            // return await models.ToListAsync();
            return await models.Skip(skipNumber).Take(searchObj.PageSize).ToListAsync();

        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var model = await _DBContext.users.FindAsync(id);
            return model;
        }


        public async Task<User?> UpdateAsync(int id, UserRequestDto userRequestDto)
        {
            var model = await _DBContext.users.FirstOrDefaultAsync(u => u.Id == id);
            if (model == null){
                return null;
            }

            model.FullName = userRequestDto.FullName;
            model.Username = userRequestDto.Username;
            model.Avatar = userRequestDto.Avatar;
            model.Wallet = userRequestDto.Wallet;
            await _DBContext.SaveChangesAsync();
            return model;
        }
    }
}