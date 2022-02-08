using OnlineAuction.Core;
using System.Linq;
using Xunit;

namespace Tests
{
    public class AuctionReceiveBid
    {
        /*
         * Nomenclaturas de nomes de testes:
         * 
         * Classe -> Nome da classe e método a ser testado
         * Método -> Retorno esperado dado um cenário
         * 
         * Informações retiradas de documentações da Microsoft
         */

        [Fact] 
        public void DoesNotAcceptNextBidGivenClientWithConsecutiveBids()
        {
            //Arranje
            var auction = new Auction("TV");
            var client = new Client("João", auction);
            auction.StartTrading();
            
            //Act
            auction.ReceiveBid(client, 400);
            auction.ReceiveBid(client, 500);
            auction.EndTrading();

            //Assert
            var expected = 1;
            var actual = auction.Bids.Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DoesNotAllowNewBidsGivenAuctionEnded()
        {
            //Arranje
            var auction = new Auction("TV");
            var client1 = new Client("João", auction);
            var client2 = new Client("Maria", auction);
            auction.StartTrading();
            auction.ReceiveBid(client1, 100);
            auction.ReceiveBid(client2, 200);
            auction.ReceiveBid(client1, 300);
            auction.EndTrading();

            //Act
            auction.ReceiveBid(client2, 400);

            //Assert
            var expected = 3;
            var actual = auction.Bids.Count();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new double[] { 100 })]
        [InlineData(new double[] { 100, 200 })]
        [InlineData(new double[] { 100, 200, 300 })]
        [InlineData(new double[] { 500, 250, 100 })]
        public void IgnoreBidsGivenAuctionNotStarted(double[] bids)
        {
            //Arranje
            var auction = new Auction("TV");
            var client = new Client("João", auction);

            //Act
            foreach (var bid in bids)
            {
                auction.ReceiveBid(client, bid);
            }
            auction.EndTrading();

            //Assert
            Bid expected = null;
            Bid actual = auction.WinnerBid;

            Assert.Equal(expected, actual);
        }
    }
}
