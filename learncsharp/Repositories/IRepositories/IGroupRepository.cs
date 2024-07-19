using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Dtos.Group;
using learnteddy.Models;

namespace learnteddy.Repositories.IRepositories
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAllAsync();

        Task<List<Group>> SearchAsync(string keysearch);

        Task<Group?> GetByIdAsync(int id);

        Task<Group> CreateAsync(Group model);

        Task<Group?> UpdateAsync(int id, GroupRequestDto groupRequestDto);

        Task<Group?> DeleteAsync(int id);

        Task<Group?> GetByNameAsync(string name);
    }
}