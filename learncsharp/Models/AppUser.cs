using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace learnteddy.Models
{
    public class AppUser : IdentityUser
    {
        //IdentityUser have username, password, retype password,...

        public List<Group> Groups {get; set;} = new List<Group>();
        public List<GroupMember> GroupMembers {get; set;} = new List<GroupMember>();
    }
}