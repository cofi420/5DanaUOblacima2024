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

        public bool AddGame(CreateGameDto game)
        {
            if (game.Duration < 1)
                return false;

            var team1 = _unitOfWork.TeamRepository.GetById(game.Team1Id);
            var team2 = _unitOfWork.TeamRepository.GetById(game.Team2Id);
            if (team1 == null
                || team2 == null
                || (game.WinningTeamId != game.Team1Id
                    && game.WinningTeamId != game.Team2Id
                    && game.WinningTeamId != null))
                return false;
            if (game.WinningTeamId == null)
            {
                var newGame = new Game(team1, team2, null, game.Duration);
                AdjustStatsForTeam(newGame, team1, 0.5);
                AdjustStatsForTeam(newGame, team2, 0.5);
                _unitOfWork.GameRepository.Add(newGame);
            }
            else
            {
                var winner = team1.Id == game.WinningTeamId ? team1 : team2;
                var loser = team1.Id == game.WinningTeamId ? team2 : team1;
                var newGame = new Game(team1, team2, winner, game.Duration);
                AdjustStatsForTeam(newGame, winner, 1);
                AdjustStatsForTeam(newGame, loser, 0);
                _unitOfWork.GameRepository.Add(newGame);
            }

            return true;
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

            return 0;
        }

        private double GetAverageTeamRating(Team team)
        {
            double sum = 0;
            foreach (var player in team.Players)
            {
                sum += player.Elo;
            }
            return sum / team.Players.Count;
        }

        private void AdjustStatsForTeam(Game game, Team team, double s)
        {
            foreach (var player in team.Players)
            {
                var newPlayer = new Player(player);
                newPlayer.HoursPlayed += game.Duration;
                newPlayer.RatingAdjustment = GetRatingAdjustment(player);
                if (s == 1)
                {
                    newPlayer.Wins++;
                }
                else if (s == 0)
                {
                    newPlayer.Losses++;
                }
                double expectedElo = 1 / (1 + Math.Round(Math.Pow(10, (GetAverageTeamRating(game.Team2) - player.Elo) / 400)));
                double newElo = player.Elo + newPlayer.RatingAdjustment * (s - expectedElo);
                newPlayer.Elo = (int)newElo;
                _unitOfWork.PlayerRepository.Update(newPlayer, newPlayer.Id);
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
