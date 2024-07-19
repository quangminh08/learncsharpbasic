using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace learnteddy.Dtos.Message
{
    public class MessageRequestDto
    {
        [Required]
        public int? SenderId {get; set;}
        [Required]
        [MaxLength(5000, ErrorMessage = "Content can not over 5000 characters")]
        public string Content {get; set;} = string .Empty; 
        public DateTime CreateDate {get; set;} = DateTime.Now;
    }
}