using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace learnteddy.Models
{
    [Table("tbl_group_member")]
    public class GroupMember
    {
        public string AppUserId {get; set;}
        public int GroupId {get; set;}

        public AppUser? AppUser{get; set;}
        public Group? Group {get; set;}

    }
}