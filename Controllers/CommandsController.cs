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
            var commandModels = _repo.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandModels));
        }

        [HttpGet("{id}", Name="GerCommandById")]
        public ActionResult<CommandReadDto> GerCommandById(int id)
        {
            var commandModel = _repo.GetCommandById(id);
            if (commandModel == null) return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(commandModel));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repo.CreateCommand(commandModel);
            _repo.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            // We'll use the CreatedAtRoute method to return 201 reponse to the client
            return CreatedAtRoute(nameof(GerCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }
    }
}