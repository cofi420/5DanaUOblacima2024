using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5DanaUOblacima2024.Domain.Entities
{
    public class Player: Entity
    {
        public string Nickname { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public int Elo { get; set; }
        public int HoursPlayed { get; set; }
        public int RatingAdjustment { get; set; }
        public Player(string nickname)
        {
            Id = Guid.NewGuid();
            Nickname = nickname;
            Wins = 0;
            Losses = 0;
            Elo = 0;
            HoursPlayed = 0;
            RatingAdjustment = 0;
        }

        public Player()
        {
            
        }

        public Player(Player p)
        {
            Id = p.Id;
            Nickname = p.Nickname;
            Wins = p.Wins;
            Losses = p.Losses;
            Elo = p.Elo;
            HoursPlayed = p.HoursPlayed;
            RatingAdjustment = p.RatingAdjustment;
        }
    }
}
