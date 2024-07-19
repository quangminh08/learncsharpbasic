using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Data;
using learnteddy.Models;
using learnteddy.Repositories.IRepositories;

namespace learnteddy.Repositories
{
    public class GroupMemberRepository : IGroupMember 
    {
        private readonly ApplicationDBContext _DBContext;

        public GroupMemberRepository(ApplicationDBContext dBContext){
            _DBContext = dBContext;
        }

        public async Task<GroupMember> CreateAsync(GroupMember groupMember)
        {
            await _DBContext.groupMembers.AddAsync(groupMember);
            await _DBContext.SaveChangesAsync();
            return groupMember;
        }

        public async Task<GroupMember> DeleteGroupMember(AppUser appUser, string groupName)
        {
            var modelFocus = _DBContext.groupMembers.FirstOrDefault(g => g.AppUserId == appUser.Id 
                                                    && g.Group.Name.ToLower() == groupName.ToLower());
            if(modelFocus == null){
                return null;
            }
            _DBContext.Remove(modelFocus);
            await _DBContext.SaveChangesAsync();
            return modelFocus;
        }

        public async Task<List<Group>> GetGroupsByUser(AppUser user)
        {
            return  _DBContext.groupMembers.Where(g => g.AppUserId == user.Id).Select(group => new Group{
                Id = group.GroupId,
                Name = group.Group.Name,
                Avatar = group.Group.Avatar
            }).ToList();
        }
    }
}