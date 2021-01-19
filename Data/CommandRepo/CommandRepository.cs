using System;
using System.Collections.Generic;
using System.Linq;
using Commander.DataAccess;
using Commander.Models;

namespace Commander.Data.CommandRepo
{
    public class CommandRepository : ICommandRepository
    {
        // private fields
        private readonly CommanderContext _context;
        // constructor
        public CommandRepository(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = _context.Commands.ToList();
            return commands;
        }

        public Command GetCommandById(int id)
        {
            var command = _context.Commands.FirstOrDefault(c => c.Id == id);
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