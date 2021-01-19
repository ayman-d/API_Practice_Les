using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data.CommandRepo
{
    public interface ICommandRepository
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(int id, Command command);
        void DeleteCommand(Command command);
    }
}