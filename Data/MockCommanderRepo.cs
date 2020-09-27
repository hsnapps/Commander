using System.Linq;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        List<Command> commands;

        public MockCommanderRepo()
        {
            commands = new List<Command>
            {
                new Command{ Id = 1, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
                new Command{ Id = 2, HowTo = "Cut bread", Line = "Get a knife", Platform = "Knife & Chopping Board" },
                new Command{ Id = 3, HowTo = "Make a cup of tea", Line = "Place taebag in a cup", Platform = "Kettle & Cup" }
            };
        }

        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(int id, Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}