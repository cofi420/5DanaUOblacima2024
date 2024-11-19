namespace _5DanaUOblacima2024.Domain.Entities
{
    public class Team: Entity
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public Team(List<Player> players, string name)
        {
            Id = Guid.NewGuid();
            Players = players;
            Name = name;
        }

        public Team()
        {
            
        }
    }
}