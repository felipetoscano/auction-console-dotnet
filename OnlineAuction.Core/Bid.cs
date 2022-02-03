namespace OnlineAuction.Core
{
    public class Bid
    {
        public Client Client { get; set; }
        public double Value { get; set; }
        public Bid(Client client, double value)
        {
            Client = client;
            Value = value;
        }
    }
}
