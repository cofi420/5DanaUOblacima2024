using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _5DanaUOblacima2024.Application.Contracts;
using _5DanaUOblacima2024.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _5DanaUOblacima2024.Persistence.Repositories
{
    public class TeamRepository : CrudRepository<Team>, ITeamRepository
    {
        public TeamRepository(DataContext dataContext) : base(dataContext)
        {
            
        }

        public new List<Team> GetAll()
        {
            return Entities.Include(t => t.Players).ToList();
        }
        public new Team GetById(Guid id)
        {
            return Entities.Include(t => t.Players).FirstOrDefault(t => t.Id == id);
        }

        public bool IsNameUnique(string name)
        {
            return Entities.All(t => t.Name!= name);
        }
    }
}
