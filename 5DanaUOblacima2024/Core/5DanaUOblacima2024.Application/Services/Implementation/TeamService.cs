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
    public class TeamService: ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Team? GetTeamById(Guid id)
        {
            return _unitOfWork.TeamRepository.GetById(id);
        }

        public Team GetTeamByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Team> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public Team? AddTeam(CreateTeamDto teamDto)
        {
            
            List<Player> players = new List<Player>();
            foreach(var p in teamDto.PlayerIds)
            {
                var player = _unitOfWork.PlayerRepository.GetById(p);
                if (player == null)
                {
                    return null;
                }
                players.Add(player);
            }
            if (PlayersConflict(players))
            {
                return null;
            }
            var team = new Team(players, teamDto.Name);
            foreach (var p in players)
            {
                p.Team = team;
                p.TeamId = team.Id;
                _unitOfWork.PlayerRepository.Update(p, p.Id);
            }
            _unitOfWork.TeamRepository.Add(team);
            return team;
        }
        private static bool PlayersConflict(List<Player> players)
        {
            foreach (var p in players)
            {
                if (p.Team != null)
                {
                    return true;
                }
            }

            return false;
        }

        public Team UpdateTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
