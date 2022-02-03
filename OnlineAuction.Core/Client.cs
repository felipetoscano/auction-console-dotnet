namespace OnlineAuction.Core
{
    public class Client
    {
        public string Name { get; set; }
        public Auction Auction { get; set; }
        public Client(string name, Auction auction)
        {
            Name = name;
            Auction = auction;
        }
    }
}
