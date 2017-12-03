using FootballTeamGenerator.Models;
using System;

namespace FootballTeamGenerator
{
    public class Startup
    {
        public static void Main()
        {
            var team = new Team("Maritsa");
            team.AddPlayer(new Player("Emil Lekov", new Stat(10, 10, 8, 9, 9)));
            team.AddPlayer(new Player("Pesho Peshev", new Stat(6, 7, 3, 3, 9)));
            team.AddPlayer(new Player("Gosho Ivanov Gonzo", new Stat(2, 1, -1, 2, 1)));

            Console.WriteLine(team.Rating);
        }
    }
}
