using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.DataAccess;
using Commander.DTOs.FeedbackDTOs;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data.CommandRepo
{
    public class CommandRepository : ICommandRepository
    {
        // private fields
        private readonly CommanderContext _context;
        // constructor
        private readonly IMapper _mapper;
        public CommandRepository(CommanderContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            var commands = await _context.Commands.Include(c => c.Feedbacks).ToListAsync();
            return commands;
        }

        public async Task<Command> GetCommandById(int id)
        {
            var command = await _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
            return command;
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Add(command);
        }

        public void UpdateCommand(int id, Command command)
        {
            var commandToEdit = _context.Commands.Find(id);

            if (commandToEdit == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            commandToEdit.HowTo = command.HowTo ?? commandToEdit.HowTo;
            commandToEdit.Line = command.Line ?? commandToEdit.Line;
            // commandToEdit.Platform = command.Platform ?? commandToEdit.Platform;
            commandToEdit.LastModified = DateTime.UtcNow;
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Remove(command);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}