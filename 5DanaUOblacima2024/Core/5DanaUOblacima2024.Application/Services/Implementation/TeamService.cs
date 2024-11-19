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

        public Team AddTeam(CreateTeamDto teamDto)
        {
            List<Player> players = new List<Player>();
            foreach(var p in teamDto.PlayerIds)
            {
                players.Add(_unitOfWork.PlayerRepository.GetById(p));
            }
            var team = new Team(players, teamDto.Name);
            _unitOfWork.TeamRepository.Add(team);
            return team;
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
