﻿namespace Forum.Services.Contracts
{
    using Forum.Data;
    using Forum.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly ForumDbContext context;

        public UserService(ForumDbContext context)
        {
            this.context = context;
        }

        public User ById(int id)
        {
            var user = context.Users.Find(id);

            return user;
        }

        public User ByUsername(string username)
        {
            var user = context
                .Users
                .Single(u => u.Username == username);

            return user;
        }

        public User ByUsernameAndPassword(string username, string password)
        {
            var user = context
                .Users
                .Single(u => u.Username == username && u.Password == password);

            return user;
        }

        public User Create(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password
            };

            context
                .Users
                .Add(user);

            context.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            var user = context
                .Users
                .Find(id);

            context
                .Users
                .Remove(user);

            context.SaveChanges();
        }
    }
}
