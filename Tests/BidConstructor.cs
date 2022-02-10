using OnlineAuction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class BidConstructor
    {
        [Fact]
        public void ThrowsArgumentExceptionGivenNegativeValue()
        {
            //Arranje
            var auction = new Auction("Carro");
            var client = new Client("João", auction);

            //Assert
            Assert.Throws<ArgumentException>(
                //Act
                () => new Bid(client, -100));
        }
    }
}
