using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Data.CommandRepo
{
    public interface ICommandRepository
    {
        Task<IEnumerable<Command>> GetAllCommands();
        Task<Command> GetCommandById(int id);
        Task<bool> CreateCommand(Command command);
        Task<bool> UpdateCommand(int id, Command command);
        Task<bool> DeleteCommand(Command command);
    }
}