namespace FootballTeamGenerator.Models
{
    public class Player
    {
        public Player(string name, Stat statistic)
        {
            this.Name = name;
            this.Statistic = statistic;
        }

        public string Name { get; set; }

        public Stat Statistic { get; set; }

        public int OverallSkillLevel()
        {
            return (this.Statistic.Dribble + this.Statistic.Endurance + this.Statistic.Passing
                + this.Statistic.Shooting + this.Statistic.Sprint)/5;
        }
    }
}
