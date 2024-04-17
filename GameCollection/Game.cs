namespace GameCollection
{
    public class Game
    {
        public Game(int id, string title, Platform platform, decimal price, bool isOwned, Store store)
        {
            Id = id;
            Title = title;
            Platform = platform;
            Price = price;
            IsOwned = isOwned;
            Store = store;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public Platform Platform { get; set; }
        public decimal Price { get; set; }
        public bool IsOwned { get; set; }
        public Store Store { get; set; }

        //public bool IsInCollection()
        //{
        //    return IsOwned;
        //}


    }
}
