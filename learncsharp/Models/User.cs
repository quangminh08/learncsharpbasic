using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace learnteddy.Models
{
    [Table("tbl_user_dontusing")]
    public class User
    {
        public int Id {get; set;}
        public string FullName {get; set;} = string.Empty;
        public string Username {get; set;} = string.Empty;
        public string Avatar {get; set;} = string.Empty;
        
        [Column(TypeName = "decimal(15,2)")]
        public decimal Wallet {get; set;}

        public List<Message> Messages {get; set;} = new List<Message>();
    }
}