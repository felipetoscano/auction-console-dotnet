namespace OnlineAuction.Core.EvaluationModality
{
    public interface IEvaluationModality
    {
        public Bid Evaluate(Auction auction);
    }
}
