using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace learnteddy.Dtos.User
{
    public class UserRequestDto
    {
        public string FullName {get; set;} = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "Username cannot over 5000 characters")]
        [MinLength(6,ErrorMessage ="Username can not be less than 6 characters")]
        public string Username {get; set;} = string.Empty;
        public string Avatar {get; set;} = string.Empty;
        [Range(0, 10000000000)]
        public decimal Wallet {get; set;}
    }
}

// Để nhận từ frontend cho create[post] và update[put] function