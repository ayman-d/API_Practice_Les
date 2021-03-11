using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Data.CommandRepo
{
    public interface ICommandRepository
    {
        bool SaveChanges();
        Task<IEnumerable<Command>> GetAllCommands();
        Task<Command> GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(int id, Command command);
        void DeleteCommand(Command command);
    }
}