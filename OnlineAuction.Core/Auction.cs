using OnlineAuction.Core.EvaluationModality;

namespace OnlineAuction.Core
{
    public class Auction
    {
        public string Piece { get; set; }
        public IList<Bid> Bids { get; set; }
        public Bid WinnerBid { get; set; }
        private IAuctionState AuctionState { get; set; }
        private IEvaluationModality EvaluationModality { get; set; }

        public Auction(string piece, IEvaluationModality evaluationModality)
        {
            Piece = piece;
            Bids = new List<Bid>();
            AuctionState = new NewAuction();
            EvaluationModality = evaluationModality;
        }

        public void ReceiveBid(Client client, double value)
        {
            AuctionState.ReceiveBid(this, client, value);
        }

        public void StartTrading()
        {
            AuctionState.StartTrading(this);
        }

        public void EndTrading()
        {
            AuctionState.EndTrading(this);
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
                if (!auction.Bids.Any() || client.Name != auction.Bids.Last().Client.Name)
                {
                    auction.Bids.Add(new Bid(client, valor));
                }
            }

            public void EndTrading(Auction auction)
            {
                auction.WinnerBid = auction.EvaluationModality.Evaluate(auction);
                auction.AuctionState = new ClosedAuction();
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
                auction.AuctionState = new OpenAuction();
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
