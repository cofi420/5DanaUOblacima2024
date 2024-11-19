using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5DanaUOblacima2024.Application.Contracts
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        IPlayerRepository PlayerRepository { get; }
        ITeamRepository TeamRepository { get; }
    }
}
