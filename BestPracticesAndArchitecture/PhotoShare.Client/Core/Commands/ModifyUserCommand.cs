namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using System;
    using System.Linq;

    public class ModifyUserCommand
    {
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public static string Execute(string[] data)
        {
            var username = data[0];
            var property = data[1];
            var newValue = data[2];

            using (var db = new PhotoShareContext())
            {
                if(!db.Users.Any(u=>u.Username == username))
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                switch (property)
                {
                    case "Password": db.Users.Where(u => u.Username == username).FirstOrDefault().Password = newValue;
                        break;
                    case "BornTown": db.Users.Where(u => u.Username == username).FirstOrDefault().BornTown.Name = newValue;
                        break;
                    case "CurrentTown":
                        db.Users.Where(u => u.Username == username).FirstOrDefault().CurrentTown.Name = newValue;
                        break;
                    default: throw new ArgumentException($"Property {property} not supported!");
                }

                db.SaveChanges();
            }

            return $"{username} was modified.";
        }
    }
}
