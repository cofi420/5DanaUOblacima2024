using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            if (game.WinnerId == null)
            {
                var newGame = new Game(team1, team2, null, game.Duration);
                AdjustStatsDraw(newGame);
                _unitOfWork.GameRepository.Add(newGame);
            }
            else
            {
                var winner = team1.Id == game.WinnerId ? team1 : team2;
                var loser = team1.Id == game.WinnerId ? team2 : team1;
                var newGame = new Game(team1, team2, winner, game.Duration);
                AdjustStatsNonDraw(newGame);
                _unitOfWork.GameRepository.Add(newGame);
            }
        }

        private int GetRatingAdjustment(Player player)
        {
            if (player.HoursPlayed < 500)
            {
                return 50;
            }
            if (player.HoursPlayed >= 500 && player.HoursPlayed < 1000)
            {
                return 40;
            }
            if (player.HoursPlayed >= 1000 && player.HoursPlayed < 3000)
            {
                return 30;
            }
            if (player.HoursPlayed >= 3000 && player.HoursPlayed < 5000)
            {
                return 20;
            }
            if (player.HoursPlayed >= 5000)
            {
                return 10;
            }
        }
        private void AdjustStatsDraw(Game game)
        {
            foreach (var player in game.Team1.Players)
            {
                double s = 0.5;
                player.HoursPlayed += game.Duration;
                player.RatingAdjustment = GetRatingAdjustment(player);
                double expectedElo = 1 / (1 + Math.Pow(10, (GetAverageTeamRating(game.Team2) - player.Elo) / 400));
                double newElo = player.Elo + player.RatingAdjustment * (s - expectedElo);
                player.Elo = (int)newElo;
                _unitOfWork.PlayerRepository.Update(player, player.Id);
            }
            foreach (var player in game.Team2.Players)
            {
                double s = 0.5;
                player.HoursPlayed += game.Duration;
                player.RatingAdjustment = GetRatingAdjustment(player);
                double expectedElo = 1 / (1 + Math.Pow(10, (GetAverageTeamRating(game.Team1) - player.Elo) / 400));
                double newElo = player.Elo + player.RatingAdjustment * (s - expectedElo);
                player.Elo = (int)newElo;
                _unitOfWork.PlayerRepository.Update(player, player.Id);
            }
        }

        private int GetAverageTeamRating(Team team)
        {
            int sum = 0;
            foreach (var player in team.Players)
            {
                sum += player.Elo;
            }
            return sum / team.Players.Count;
        }
        private void AdjustStatsNonDraw(Game game, Team winner, Team loser)
        {
            foreach (var player in winner.Players)
            {
                double s = 0.5;
                player.HoursPlayed += game.Duration;
                player.RatingAdjustment = GetRatingAdjustment(player);
                player.Wins++;
                double expectedElo = 1 / (1 + Math.Pow(10, (GetAverageTeamRating(game.Team2) - player.Elo) / 400));
                double newElo = player.Elo + player.RatingAdjustment * (s - expectedElo);
                player.Elo = (int)newElo;
                _unitOfWork.PlayerRepository.Update(player, player.Id);
            }
            foreach (var player in loser.Players)
            {
                double s = 0.5;
                player.HoursPlayed += game.Duration;
                player.RatingAdjustment = GetRatingAdjustment(player);
                player.Losses++;
                double expectedElo = 1 / (1 + Math.Pow(10, (GetAverageTeamRating(game.Team1) - player.Elo) / 400));
                double newElo = player.Elo + player.RatingAdjustment * (s - expectedElo);
                player.Elo = (int)newElo;
                _unitOfWork.PlayerRepository.Update(player, player.Id);
            }
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
