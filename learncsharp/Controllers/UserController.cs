using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using learnteddy.Data;
using learnteddy.Dtos.Message;
using learnteddy.Dtos.User;
using learnteddy.Mappers;
using learnteddy.Models;
using learnteddy.Repositories;



/* Cả Mvc và components đều có Route, Cần chọn phù hợp với present context*/
// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learnteddy.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository){
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAllUsers(){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 

            var users = await _userRepository.GetAllAsync();    
            var userDtos = users.Select(s => s.UserToDto()) ;
            return Ok(userDtos);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> SearchUsers([FromQuery] UserFilter searchObj){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 

            var users = await _userRepository.SearchAsync(searchObj);    
            var userDtos = users.Select(s => s.UserToDto()) ;
            return Ok(userDtos);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> getUser([FromRoute] int id){
            // dấu ở cuối ! là chấp nhận gián trị null cho đối tượng đó
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var user = await _userRepository.GetByIdAsync(id);

            if(user == null){
                return NotFound();
            }

            return Ok(user.UserToDto());
        }


        [HttpPost]
        public async Task<IActionResult> addUser([FromBody] UserRequestDto requestDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var model = requestDto.RequestDtoToModel();
            await _userRepository.CreateAsync(model);
            return CreatedAtAction(nameof(getUser), new {id = model.Id}, model.UserToDto());
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> updateUser([FromRoute] int id, [FromBody] UserRequestDto requestDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var model = await _userRepository.UpdateAsync(id, requestDto);
            if (model == null){
                return NotFound();
            }
            return Ok(model.UserToDto());
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> deleteUser([FromRoute] int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var model = await _userRepository.DeleteAsync(id);
            if (model == null){
                return NotFound();
            }
            return NoContent();
        }

        // [FromQuery] <=> RequestParam
        // [FromHeader]
        // [FromForm]
    }
}