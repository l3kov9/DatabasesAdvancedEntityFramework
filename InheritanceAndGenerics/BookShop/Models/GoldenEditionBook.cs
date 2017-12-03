namespace BookShop.Models
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price) 
            : base(title, author, price)
        {
            this.Price = 13 / 10.0m * price;
        }
    }
}
