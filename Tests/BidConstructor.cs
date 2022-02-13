using OnlineAuction.Core;
using OnlineAuction.Core.EvaluationModality;
using System;
using Xunit;

namespace Tests
{
    public class BidConstructor
    {
        [Fact]
        public void ThrowsArgumentExceptionGivenNegativeValue()
        {
            //Arranje
            var modality = new HighestValue();
            var auction = new Auction("Carro", modality);
            var client = new Client("João", auction);

            //Assert
            Assert.Throws<ArgumentException>(
                //Act
                () => new Bid(client, -100));
        }
    }
}
