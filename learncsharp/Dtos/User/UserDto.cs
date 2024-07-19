using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace learnteddy.Dtos.User
{
    public class UserDto
    {
        public int Id {get; set;}
        public string FullName {get; set;} = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "Username can not over 5000 characters")]
        [MinLength(6,ErrorMessage ="Username can not be less than 6 characters")]
        public string Username {get; set;} = string.Empty;
        public string Avatar {get; set;} = string.Empty;
        public decimal Wallet {get; set;}
    }
}

// để trả về cho frontend