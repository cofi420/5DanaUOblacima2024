using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5DanaUOblacima2024.Application.Dto;
using _5DanaUOblacima2024.Domain.Entities;

namespace _5DanaUOblacima2024.Application.Services.Interface
{
    public interface ITeamService
    {
        Team? GetTeamById(Guid id);
        Team GetTeamByName(string name);
        List<Team> GetAllTeams();
        Team AddTeam(CreateTeamDto teamDto);
        Team UpdateTeam(Team team);
        void DeleteTeam(Guid id);
    }
}
