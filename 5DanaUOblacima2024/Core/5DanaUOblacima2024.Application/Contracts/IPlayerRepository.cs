using _5DanaUOblacima2024.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5DanaUOblacima2024.Application.Contracts
{
    public interface IPlayerRepository: ICrudRepository<Player>
    {
        bool IsNicknameUnique(string nickname);
    }
}
