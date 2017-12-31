namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Data;

    public class DeleteUser
    {
        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string username = data[1];
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new InvalidOperationException($"User with {username} was not found!");
                }

                context.Users.Where(u => u.Username == username).First().IsDeleted = true;
                context.SaveChanges();

                return $"User {username} was deleted from the database!";
            }
        }
    }
}
