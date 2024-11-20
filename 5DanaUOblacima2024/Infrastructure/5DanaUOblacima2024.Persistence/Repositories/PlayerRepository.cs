using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _5DanaUOblacima2024.Application.Contracts;
using _5DanaUOblacima2024.Domain.Entities;

namespace _5DanaUOblacima2024.Persistence.Repositories
{
    public class PlayerRepository : CrudRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DataContext dataContext) : base(dataContext)
        {
        }
        public bool IsNicknameUnique(string nickname)
        {
            return Entities.All(p => p.Nickname != nickname);
        }

        public new Player Update(Player entity, Guid id)
        {
            var player = Entities.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return null;
            }
            player.Nickname = entity.Nickname;
            player.Wins = entity.Wins;
            player.Losses = entity.Losses;
            player.Elo = entity.Elo;
            player.HoursPlayed = entity.HoursPlayed;
            player.RatingAdjustment = entity.RatingAdjustment;
            //DbContext.SaveChanges();
            return player;
        }
    }
}
