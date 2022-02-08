using OnlineAuction.Core;
using Xunit;

namespace Tests
{
    public class AuctionEndTrading
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
        public void HighestValueGivenAnAuctionWith3Clients()
        {
            //Arranje
            var auction = new Auction("IPhone 13");
            var client1 = new Client("Felipe", auction);
            var client2 = new Client("João", auction);
            var client3 = new Client("Maria", auction);

            auction.StartTrading();
            auction.ReceiveBid(client1, 5000);
            auction.ReceiveBid(client2, 6000);
            auction.ReceiveBid(client1, 7000);
            auction.ReceiveBid(client2, 1000);
            auction.ReceiveBid(client3, 15000);
            auction.ReceiveBid(client1, 500);
            auction.ReceiveBid(client3, 3000);

            //Act
            auction.EndTrading();

            //Assert
            var actual = auction.WinnerBid.Value;
            var expected = 15000;

            Assert.Equal(expected, actual);
            Assert.Equal(client3, auction.WinnerBid.Client);
        }

        [Theory]
        [InlineData(8000, new double[] { 5000, 6000, 7000, 8000 })]
        [InlineData(7000, new double[] { 5000, 6000, 7000, 1000 })]
        [InlineData(5000, new double[] { 5000 })]
        [InlineData(0, new double[] { })]
        public void HighestValueGivenAnAuction(double expected, double[] bidsValues)
        {
            //Arranje
            var auction = new Auction("IPhone 13");
            var client1 = new Client("Felipe", auction);
            var client2 = new Client("João", auction);
            auction.StartTrading();

            for (int i = 0; i < bidsValues.Length; i++)
            {
                if((i%2) == 0)
                {
                    auction.ReceiveBid(client1, bidsValues[i]);
                }
                else
                {
                    auction.ReceiveBid(client2, bidsValues[i]);
                }
            }

            //Act
            auction.EndTrading();


            //Assert
            var actual = auction.WinnerBid.Value;

            Assert.Equal(expected, actual);
        }
    }
}
