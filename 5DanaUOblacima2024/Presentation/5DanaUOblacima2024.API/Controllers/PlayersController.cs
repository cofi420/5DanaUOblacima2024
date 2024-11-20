using _5DanaUOblacima2024.Application.Dto;
using _5DanaUOblacima2024.Application.Services.Interface;
using _5DanaUOblacima2024.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _5DanaUOblacima2024.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult GetPlayers()
        {
            return Ok(_playerService.GetAllPlayers());
        }
        [HttpGet("{playerId}")]
        public IActionResult GetPlayerById(Guid playerId)
        {
            if (_playerService.GetPlayerById(playerId) == null)
            {
                return NotFound();
            }
            return Ok(_playerService.GetPlayerById(playerId));
        }

        [HttpPost("create")]
        public IActionResult CreatePlayer([FromBody] CreatePlayerDto playerDto)
        {
            var player = _playerService.AddPlayer(playerDto);
            if (player == null)
            {
                return Conflict("Nickname is not unique");
            }
            return Ok(player);
        }
    }
}
