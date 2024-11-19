using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5DanaUOblacima2024.Application.Contracts;
using _5DanaUOblacima2024.Domain.Entities;

namespace _5DanaUOblacima2024.Persistence.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        public IGameRepository GameRepository { get; }
        public IPlayerRepository PlayerRepository { get; }
        public ITeamRepository TeamRepository { get; }
        public UnitOfWork(
            IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            ITeamRepository teamRepository)
        {
            GameRepository = gameRepository;
            PlayerRepository = playerRepository;
            TeamRepository = teamRepository;
        }
    }
}
