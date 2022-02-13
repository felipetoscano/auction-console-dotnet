namespace OnlineAuction.Core.EvaluationModality
{
    public class ClosestSuperior : IEvaluationModality
    {
        public double DestinationValue { get; set; }

        public ClosestSuperior(double destinationValue)
        {
            DestinationValue = destinationValue;
        }

        public Bid Evaluate(Auction auction)
        {
            return auction.Bids.Where(b => b.Value > DestinationValue).OrderBy(b => b.Value).FirstOrDefault(new Bid(null, 0));
        }
    }
}
