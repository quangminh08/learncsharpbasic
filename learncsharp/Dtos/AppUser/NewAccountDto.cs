using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learnteddy.Dtos.AppUser
{
    public class NewAccountDto
    {
        public string? UserName {get; set;}
        public string? Email {get; set;}
        public string? Token {get; set;}
    }
}