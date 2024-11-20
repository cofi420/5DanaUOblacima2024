using _5DanaUOblacima2024.Application.Dto;
using _5DanaUOblacima2024.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace _5DanaUOblacima2024.API.Controllers
{
    [ApiController]
    [Route("matches")]
    public class GamesController: ControllerBase
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet("{gameId}")]
        public IActionResult GetGameById(Guid gameId)
        {
            if (_gameService.GetGameById(gameId) == null)
            {
                return NotFound();
            }
            return Ok(_gameService.GetGameById(gameId));
        }
        [HttpPost]
        public IActionResult CreateGame([FromBody] CreateGameDto gameDto)
        {
            var success = _gameService.AddGame(gameDto);
            if (success)
                return Ok();
            return BadRequest();
        }
    }
}
