namespace FootballTeamGenerator.Models
{
    public class Stat
    {
        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance { get; set; }

        public int Sprint { get; set; }
        
        public int Dribble { get; set; }

        public int Passing { get; set; }

        public int Shooting { get; set; }

        public int AverageStat()
        {
            return (this.Endurance+this.Shooting+this.Sprint+this.Dribble+this.Passing)/ 5;
        }
    }
}
