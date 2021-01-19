using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.DataAccess
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        {

        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}