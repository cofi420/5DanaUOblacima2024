using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5DanaUOblacima2024.Domain.Entities
{
    public class Game: Entity
    {
        public Team Team1 { get; set; }
        public Guid Team1Id { get; set; }
        public Team Team2 { get; set; }
        public Guid Team2Id { get; set; }
        public Team? Winner { get; set; }
        public Guid? WinnerId { get; set; }
        public int Duration { get; set; }
        public Game(Team team1, Team team2, Team winner, int duration)
        {
            Team1 = team1;
            Team2 = team2;
            Winner = winner;
            Duration = duration;
        }
        public Game()
        {

        }
    }
}
