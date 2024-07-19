using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Data;
using learnteddy.Dtos.Group;
using learnteddy.Models;
using learnteddy.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace learnteddy.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        
        private readonly ApplicationDBContext _DBContext;

        public GroupRepository(ApplicationDBContext applicationDBContext){
            _DBContext = applicationDBContext;
        }

        public async Task<Group> CreateAsync(Group model)
        {
            await _DBContext.AddAsync(model);
            await _DBContext.SaveChangesAsync();
            return model;
        }

        public async Task<Group?> DeleteAsync(int id)
        {
            var model = await _DBContext.groups.FirstOrDefaultAsync(g => g.Id == id);
            if (model == null){
                return null;
            }
            // Không thêm await vì Remove không phải là một chức năng không đồng bộ
            _DBContext.groups.Remove(model);
            await _DBContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<Group>> GetAllAsync()
        {
            var models = await _DBContext.groups.ToListAsync();
            return models;
        }

        public async Task<Group?> GetByIdAsync(int id)
        {
            var model = await _DBContext.groups.FindAsync(id);
            return model;
        }

        public async Task<Group?> GetByNameAsync(string name)
        {
            var model = await _DBContext.groups.FirstOrDefaultAsync(g => g.Name == name);
            return model;
        }

        public async Task<List<Group>> SearchAsync(string keysearch)
        {
            var models = _DBContext.groups.AsQueryable();
            if(!string.IsNullOrWhiteSpace(keysearch)){
                models = models.Where(u => u.Name.Contains(keysearch));
            } 
            return await models.ToListAsync();
        }

        public async Task<Group?> UpdateAsync(int id, GroupRequestDto groupRequestDto)
        {
            var model = await _DBContext.groups.FirstOrDefaultAsync(u => u.Id == id);
            if (model == null){
                return null;
            }
            model.Name = groupRequestDto.Name!;
            model.Avatar = groupRequestDto.Avatar!;
            await _DBContext.SaveChangesAsync();
            return model;
        }
    }
}