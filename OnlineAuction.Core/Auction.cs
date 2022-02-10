namespace OnlineAuction.Core
{
    public class Auction
    {
        private IList<Bid> _bids;
        private IAuctionState _auctionState { get; set; }

        public IEnumerable<Bid> Bids => _bids;
        public string Piece { get; }
        public Bid WinnerBid { get; set; }

        public Auction(string piece)
        {
            Piece = piece;
            _auctionState = new NewAuction();
            _bids = new List<Bid>();
        }

        public void ReceiveBid(Client client, double value)
        {
            _auctionState.ReceiveBid(this, client, value);
        }

        public void StartTrading()
        {
            _auctionState.StartTrading(this);
        }

        public void EndTrading()
        {
            _auctionState.EndTrading(this);
        }

        interface IAuctionState
        {
            void ReceiveBid(Auction auction, Client client, double valor);
            void StartTrading(Auction auction);
            void EndTrading(Auction auction);
        }

        class OpenAuction : IAuctionState
        {
            public void StartTrading(Auction auction)
            {

            }

            public void ReceiveBid(Auction auction, Client client, double valor)
            {
                if(!auction.Bids.Any() || client.Name != auction._bids.Last().Client.Name)
                {
                    auction._bids.Add(new Bid(client, valor));
                }
            }

            public void EndTrading(Auction auction)
            {
                auction.WinnerBid = auction.Bids.OrderBy(b => b.Value).LastOrDefault(new Bid(null, 0));
                auction._auctionState = new ClosedAuction();
            }
        }

        class ClosedAuction : IAuctionState
        {
            public void StartTrading(Auction auction)
            {

            }

            public void ReceiveBid(Auction auction, Client client, double valor)
            {

            }

            public void EndTrading(Auction auction)
            {

            }
        }

        class NewAuction : IAuctionState
        {
            public void StartTrading(Auction auction)
            {
                auction._auctionState = new OpenAuction();
            }

            public void ReceiveBid(Auction auction, Client client, double valor)
            {

            }

            public void EndTrading(Auction auction)
            {
                throw new InvalidOperationException("Pregão deve ser iniciado antes");
            }
        }
    }


}
