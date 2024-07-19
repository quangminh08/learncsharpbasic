using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using learnteddy.Dtos.AppUser;
using learnteddy.Dtos.User;
using learnteddy.Models;
using learnteddy.Service.IService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learnteddy.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager){
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }


        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody]LoginDto loginDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var account = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName!.CompareTo(loginDto.UserName)==0 ); //== loginDto.UserName.ToLower());
            if(account == null){
                return Unauthorized("Invalid username");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(account!, loginDto.Password!, false);

            if(!result.Succeeded){
                return Unauthorized("Password incorrect");
            }

            return Ok(
                new NewAccountDto{
                    UserName = account.UserName,
                    Email = account.Email,
                    Token = _tokenService.CreateToken(account)
                }
            );
        }


        [HttpPost("register")] // password "User0123*"
        public async Task<IActionResult> register([FromBody] RegisterDto registerDto){
            try{
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                // create user with dto information
                var appUser = new AppUser{
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };
                // follow appuser create createdUser with password and roles 
                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password!);
                if(createdUser.Succeeded){ // if create is congratulation
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if(roleResult.Succeeded){
                        // return Ok("User created");
                        return Ok(
                            new NewAccountDto{
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenService.CreateToken(appUser)
                            }
                        );
                    }else{
                        return StatusCode(500, roleResult.Errors);
                    }
                }else {
                    return StatusCode(500, createdUser.Errors);
                }
                
            }catch(Exception e){
                return StatusCode(500, e);
            }
        }
    }
}