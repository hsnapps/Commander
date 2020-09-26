using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    // We can inherit from Microsoft.AspNetCore.Mvc.Controller but it will lead us to views not API
    [Route("api/commands")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommanderRepo _repo;

        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var items = _repo.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(items));
        }

        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GerCommandById(int id)
        {
            var item = _repo.GetCommandById(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(item));
        }
    }
}