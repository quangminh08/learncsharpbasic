using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace learnteddy.Dtos.Group
{
    public class GroupRequestDto
    {
        [Required]
        public string? Name {get; set;} = string.Empty;
        public string? Avatar {get; set;} = string.Empty;
    }
}