﻿namespace Forum.Data.Models
{
    public class Reply
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
