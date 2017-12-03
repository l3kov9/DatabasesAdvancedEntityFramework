using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        public string Name { get; set; }

        public List<Player> players;

        public int Rating
        {
            get => (int)this.players.Average(p => p.Statistic.AverageStat());
            set
            {
                this.Rating = value;
            }
        }

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
    }
}
