using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace learnteddy.Extensions
{
    public static class ClaimsExtensions
    {
        // get logined username
        public static string GetUsername(this ClaimsPrincipal user){
            // trong Equals chỉ là một link ngẫu nhiên
            return user.Claims.SingleOrDefault(x => 
                            x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
        }
    }
}