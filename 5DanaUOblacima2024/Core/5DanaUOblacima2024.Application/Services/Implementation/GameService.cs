using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5DanaUOblacima2024.Application.Contracts;
using _5DanaUOblacima2024.Application.Dto;
using _5DanaUOblacima2024.Application.Services.Interface;
using _5DanaUOblacima2024.Domain.Entities;

namespace _5DanaUOblacima2024.Application.Services.Implementation
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Game GetGameById(Guid id)
        {
            return _unitOfWork.GameRepository.GetById(id);
        }

        public List<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public void AddGame(CreateGameDto game)
        {   
            var team1 = _unitOfWork.TeamRepository.GetById(game.Team1Id);
            var team2 = _unitOfWork.TeamRepository.GetById(game.Team2Id);
            var winner = team1.Id == game.WinnerId ? team1 : team2;
            _unitOfWork.GameRepository.Add(new Game(team1, team2, winner, game.Duration));
        }

        public Game UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void DeleteGame(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
