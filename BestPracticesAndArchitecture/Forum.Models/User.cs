﻿namespace Forum.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
