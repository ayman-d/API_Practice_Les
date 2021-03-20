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
            var command = await _context.Commands.Include(c => c.Feedbacks).FirstOrDefaultAsync(c => c.Id == id);
            return command;
        }

        public async Task<bool> CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            await _context.Commands.AddAsync(command);
            int itemsSaved = await _context.SaveChangesAsync();
            if (itemsSaved <= 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateCommand(int id, Command command)
        {
            var commandToEdit = await _context.Commands.FindAsync(id);

            if (commandToEdit == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            commandToEdit.HowTo = command.HowTo ?? commandToEdit.HowTo;
            commandToEdit.Line = command.Line ?? commandToEdit.Line;
            commandToEdit.Platform = command.Platform ?? commandToEdit.Platform;
            commandToEdit.LastModified = DateTime.UtcNow;

            int itemsSaved = await _context.SaveChangesAsync();

            if (itemsSaved <= 0)
            {
                return false;
            }

            return true;

        }

        public async Task<bool> DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Remove(command);
            int itemsSaved = await _context.SaveChangesAsync();

            if (itemsSaved <= 0)
            {
                return false;
            }

            return true;
        }
    }
}