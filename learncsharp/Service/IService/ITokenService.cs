using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Models;

namespace learnteddy.Service.IService
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}