using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace learnteddy.Models
{
    [Table("tbl_group")] //set table's name in MSSQL
    public class Group
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string Avatar {get; set;} = string.Empty;
        public List<AppUser> AppUsers {get; set;} = new List<AppUser>();
        public List<GroupMember> GroupMembers {get; set;} = new List<GroupMember>();
    }
}