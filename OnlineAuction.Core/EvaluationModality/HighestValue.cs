namespace OnlineAuction.Core.EvaluationModality
{
    public class HighestValue : IEvaluationModality
    {
        public Bid Evaluate(Auction auction)
        {
            return auction.Bids.OrderBy(b => b.Value).LastOrDefault(new Bid(null, 0));
        }
    }
}
