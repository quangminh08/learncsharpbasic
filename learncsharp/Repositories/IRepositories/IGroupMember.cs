using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Models;

namespace learnteddy.Repositories.IRepositories
{
    public interface IGroupMember
    {
        Task<List<Group>> GetGroupsByUser(AppUser user);
        Task<GroupMember> CreateAsync(GroupMember groupMember);
        Task<GroupMember> DeleteGroupMember(AppUser appUser, string groupName);

    }
}