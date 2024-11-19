using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5DanaUOblacima2024.Application.Contracts;
using _5DanaUOblacima2024.Domain.Entities;

namespace _5DanaUOblacima2024.Persistence.Repositories
{
    public class GameRepository : CrudRepository<Game>, IGameRepository
    {
        public GameRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
