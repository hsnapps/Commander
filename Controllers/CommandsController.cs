using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    // We can inherit from Microsoft.AspNetCore.Mvc.Controller but it will lead us to views not API
    [Route("api/commands")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        private readonly ICommanderRepo _repo;

        // private readonly MockCommanderRepo _repo = new MockCommanderRepo();

        public CommandsController(ICommanderRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var items = _repo.GetAllCommands();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GerCommandById(int id)
        {
            var item = _repo.GetCommandById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}