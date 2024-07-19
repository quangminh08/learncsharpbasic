using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace learnteddy.Models
{
    [Table("tbl_message")]
    public class Message
    {

        public int Id {get;set;}
        public int? SenderId {get; set;}

        // navigation property
        public User? Sender {get; set;}

        public string Content {get; set;} = string .Empty; 

        public DateTime CreateDate {get; set;} = DateTime.Now;
    }
}