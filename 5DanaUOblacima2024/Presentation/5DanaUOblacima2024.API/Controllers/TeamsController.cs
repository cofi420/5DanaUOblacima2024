using _5DanaUOblacima2024.Application.Dto;
using _5DanaUOblacima2024.Application.Services.Interface;
using _5DanaUOblacima2024.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _5DanaUOblacima2024.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController: ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet("{teamId}")]
        public IActionResult GetTeamById(Guid teamId)
        {
            return Ok(_teamService.GetTeamById(teamId));
        }
        [HttpPost]
        public IActionResult CreateTeam([FromBody] CreateTeamDto teamDto)
        {
            var team = _teamService.AddTeam(teamDto);
            return Ok(team);
        }
    }
}
