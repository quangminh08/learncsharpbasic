using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Extensions;
using learnteddy.Models;
using learnteddy.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace learnteddy.Controllers
{
    [ApiController]
    [Route("api/group-members")]
    public class GroupMemberController : ControllerBase

    {


        private readonly UserManager<AppUser> _userManager;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupMember _groupMemberRepo;
        public GroupMemberController(UserManager<AppUser> userManager, IGroupRepository groupRepository,
                                    IGroupMember groupMember){
            _userManager = userManager;
            _groupRepository = groupRepository;
            _groupMemberRepo = groupMember;
        }

        [HttpGet("/is-member-of-groups")]
        [Authorize]
        public async Task<IActionResult> getGroupsOfUser(){
            // User ở đây là ClaimsPrincipal User
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userGroups = await _groupMemberRepo.GetGroupsByUser(appUser);
            return Ok(userGroups);
        }// swagge chưa có bearer dùng postman ok

        [HttpPost("add-groupmember")]
        [Authorize]
        public async Task<IActionResult> addGrMem([FromQuery] string name){
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var group = await _groupRepository.GetByNameAsync(name);
            if (group == null){
                return BadRequest("group not found");
            }

            var groupMember = await _groupMemberRepo.GetGroupsByUser(appUser);
            if(groupMember.Any(g => g.Name.ToLower() == name.ToLower())){
                return BadRequest("User already joined group");
            }

            var groupMemberObject = new GroupMember{
                AppUserId = appUser.Id,
                GroupId = group.Id
            };

            await _groupMemberRepo.CreateAsync(groupMemberObject);

            if(groupMemberObject == null){
                return StatusCode(500, "Could not add");
            }else{
                return Created();
            }
        }

        [HttpDelete("delete-groupmember")]
        [Authorize]
        public async Task<IActionResult> deleteGroupMember(string groupName){
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var groupMember = await _groupMemberRepo.GetGroupsByUser(appUser);


            var filteredGroup = groupMember.Where(g => g.Name.ToLower() == groupName.ToLower());

            if(filteredGroup.Count() >= 1){
                await _groupMemberRepo.DeleteGroupMember(appUser, groupName);
            }else{
                return BadRequest(" User not in group");
            }

            return Ok();
        }
    }
}