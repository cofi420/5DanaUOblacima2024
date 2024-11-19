using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5DanaUOblacima2024.Application.Dto;
using _5DanaUOblacima2024.Domain.Entities;

namespace _5DanaUOblacima2024.Application.Services.Interface
{
    public interface IGameService
    {
        Game GetGameById(Guid id);
        List<Game> GetAllGames();
        void AddGame(CreateGameDto game);
        Game UpdateGame(Game game);
        void DeleteGame(Guid id);
    }
}
