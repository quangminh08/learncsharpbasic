using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Data;
using learnteddy.Dtos.Message;
using learnteddy.Mappers;
using learnteddy.Repositories.IRepositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace learnteddy.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository){
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getMessages(){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var models = await _messageRepository.GetAllAsync();
            var messageDtos = models.Select(s => s.MessageToDto()) ;
            return Ok(messageDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getMessageById([FromRoute] int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var model = await _messageRepository.GetByIdAsync(id);
            if (model == null){
                return NotFound();
            }

            return Ok(model.MessageToDto());
        }


        [HttpPost]
        public async Task<IActionResult> addMessage([FromBody] MessageRequestDto requestDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var model = requestDto.RequestDtoToMessage();
            await _messageRepository.CreateAsync(model);
            return CreatedAtAction(nameof(getMessageById), new {id = model.Id}, model.MessageToDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> updateMessage([FromBody] MessageRequestDto requestDto, [FromRoute] int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var model = await _messageRepository.UpdateAsync(id, requestDto);
            if (model == null){
                return NotFound();
            }
            return Ok(model.MessageToDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> deleteMessage([FromRoute] int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 
            var model = await _messageRepository.DeleteAsync(id);
            if (model == null){
                return NotFound();
            }
            return NoContent();
        }
    }
}