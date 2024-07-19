using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learnteddy.Dtos.User
{
    public class UserFilter
    {
        public string? FullName {get; set;} = null;
        public string? Avatar {get; set;} = null;
        public string? SortBy {get; set;} = null;
        public Boolean IsDecsending {get; set;} = false;
        public int PageNumber {get; set;} = 1;
        public int PageSize {get; set;} = 2;//10

    }
}