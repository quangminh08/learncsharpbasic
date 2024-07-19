using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Dtos.User;
using learnteddy.Models;

namespace learnteddy.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<List<User>> SearchAsync(UserFilter searchObj);

        Task<User?> GetByIdAsync(int id);

        Task<User> CreateAsync(User model);

        Task<User?> UpdateAsync(int id, UserRequestDto userRequestDto);

        Task<User?> DeleteAsync(int id);
    }
}