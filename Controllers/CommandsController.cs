using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data.CommandRepo;
using Commander.DTOs.CommandDTOs;
using Commander.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository _commandRepository;
        public CommandsController(
            ICommandRepository commandRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _commandRepository = commandRepository;
        }

        // GET api/commands
        [HttpGet]
        // [Authorize(Roles = "Admin")]
        [Authorize]

        public async Task<ActionResult> GetAllCommands()
        {
            var commands = await _commandRepository.GetAllCommands();
            if (commands == null)
            {
                return NotFound(new { message = "No commands found in the DB at this time" });
            }
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        // GET api/commands/{id}
        // we give this method a name so we can use it elsewhere (in the create section to return the new object upon successful creation of items)
        [HttpGet("{id}", Name = "GetCommandById")]
        // [Authorize]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetCommandById(int id)
        {
            var command = await _commandRepository.GetCommandById(id);
            if (command == null)
            {
                return NotFound(new { message = "This command Id was not found in the database" });
            }
            return Ok(_mapper.Map<CommandReadDTO>(command));
        }

        // POST api/commands
        [HttpPost]
        public async Task<ActionResult> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
            var newCommand = _mapper.Map<Command>(commandCreateDTO);

            bool successful = await _commandRepository.CreateCommand(newCommand);

            if (!successful)
            {
                return BadRequest(new { message = "Something went wrong, request not completed" });
            }

            var newCommandReadDto = _mapper.Map<CommandReadDTO>(newCommand);

            return CreatedAtRoute(nameof(GetCommandById), new { id = newCommandReadDto.Id }, newCommandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
        {
            var lookForCommand = await _commandRepository.GetCommandById(id);

            if (lookForCommand == null)
            {
                return NotFound(new { message = "Could not find a command to edit with that Id." });
            }

            var commandToUpdate = _mapper.Map<Command>(commandUpdateDTO);

            bool successful = await _commandRepository.UpdateCommand(id, commandToUpdate);

            if (!successful)
            {
                return BadRequest(new { message = "Something went wrong, edit request not completed" });
            }

            return Ok(new { message = $"Record with Id {id} edited successfully" });
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommand(int id)
        {
            var commandToDelete = await _commandRepository.GetCommandById(id);

            if (commandToDelete == null)
            {
                return NotFound(new { message = "Record with given Id cannot be found" });
            }

            bool successful = await _commandRepository.DeleteCommand(commandToDelete);

            if (!successful)
            {
                return BadRequest(new { message = "Something went wrong, delete request not complete" });
            }

            return Ok(new { message = "Record successfully deleted" });
        }
    }
}