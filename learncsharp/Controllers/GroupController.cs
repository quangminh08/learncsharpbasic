using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Data;
using learnteddy.Dtos.Group;
using learnteddy.Mappers;
using learnteddy.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace learnteddy.Controllers
{
    [ApiController]
    [Route("api/groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepo;

        public GroupController(IGroupRepository groupRepository){
            _groupRepo = groupRepository;
        }


        [HttpGet]
        public async Task<IActionResult> getAllGroup(){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 

            var groups = await _groupRepo.GetAllAsync();
            var groupDtos = groups.Select(g => g.GroupToDto());
            return Ok(groupDtos);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> SearchGroups([FromQuery] string keysearch){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var groups = await _groupRepo.SearchAsync(keysearch);   
            var groupDtos = groups.Select(g => g.GroupToDto());
            return Ok(groupDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getGroup([FromRoute] int id){
            // dấu ở cuối ! là chấp nhận gián trị null cho đối tượng đó
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var group = await _groupRepo.GetByIdAsync(id);

            if(group == null){
                return NotFound();
            }
            return Ok(group.GroupToDto());
        }


        [HttpPost]
        public async Task<IActionResult> addMessage([FromBody] GroupRequestDto requestDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var model = requestDto.RequestDtoToModel();
            await _groupRepo.CreateAsync(model);
            return CreatedAtAction(nameof(getGroup), new {id = model.Id}, model.GroupToDto());
        }

       [HttpPut("{id:int}")]
        public async Task<IActionResult> updateGroup([FromBody] GroupRequestDto requestDto, [FromRoute] int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var model = await _groupRepo.UpdateAsync(id, requestDto);
            if (model == null){
                return NotFound();
            }
            return Ok(model.GroupToDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> deleteGroup([FromRoute] int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var model = await _groupRepo.DeleteAsync(id);
            if (model == null){
                return NotFound();
            }
            return NoContent();
        }

    }
}