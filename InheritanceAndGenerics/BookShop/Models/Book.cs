using System;

namespace BookShop.Models
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Title
        {
            get => this.title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get => this.author;
            set
            {
                if (char.IsDigit(value[0]))
                {
                    throw new ArgumentException("Author not valid");
                }

                this.author = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid price");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}" + Environment.NewLine +
        $"Title: {this.Title}" + Environment.NewLine +
        $"Author: {this.Author}" + Environment.NewLine +
        $"Price: {this.Price:f2}";
        }
    }
}
