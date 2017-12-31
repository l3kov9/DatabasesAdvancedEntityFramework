namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Data;
    using System.Linq;
    using System;

    public class AddTownCommand
    {
        // AddTown <townName> <countryName>
        public static string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                if(context.Towns.Any(t=>t.Name == town.Name))
                {
                    throw new ArgumentException($"Town {town.Name} was already added!");
                }

                context.Towns.Add(town);
                context.SaveChanges();

                return townName + " was added to database!";
            }
        }
    }
}
