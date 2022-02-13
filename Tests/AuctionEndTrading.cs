using OnlineAuction.Core;
using OnlineAuction.Core.EvaluationModality;
using System;
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

        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250 })]
        [InlineData(1000, 1001, new double[] { 800, 1000, 1001, 1100 })]
        [InlineData(800, 2000, new double[] { 2000, 3000, 5000, 10000 })]
        public void ClosestValueGivenAuctionInThisModality(
            double destinationValue,
            double expected,
            double[] bidsValues)
        {
            //Arranje
            var modality = new ClosestSuperior(destinationValue);
            var auction = new Auction("IPhone 13", modality);
            var client1 = new Client("Felipe", auction);
            var client2 = new Client("João", auction);
            auction.StartTrading();

            for (int i = 0; i < bidsValues.Length; i++)
            {
                if ((i % 2) == 0)
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

        [Fact]
        public void HighestValueGivenAnAuctionWith3Clients()
        {
            //Arranje
            var modality = new HighestValue();
            var auction = new Auction("IPhone 13", modality);
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

        [Fact]
        public void ThrowInvalidOperationExceptionGivenAuctionEndedAndNotStarted()
        {
            //Arranje
            var modality = new HighestValue();
            var auction = new Auction("PS5", modality);

            /* Forma "Gambiarra"
            try
            {
                //Act
                auction.EndTrading();
                Assert.True(false);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsType<InvalidOperationException>(ex);
            }
            */

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(
                //Act
                () => auction.EndTrading());

            var actual = exception.Message;
            var expected = "Pregão deve ser iniciado antes";
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8000, new double[] { 5000, 6000, 7000, 8000 })]
        [InlineData(7000, new double[] { 5000, 6000, 7000, 1000 })]
        [InlineData(5000, new double[] { 5000 })]
        [InlineData(0, new double[] { })]
        public void HighestValueGivenAnAuction(double expected, double[] bidsValues)
        {
            //Arranje
            var modality = new HighestValue();
            var auction = new Auction("IPhone 13", modality);
            var client1 = new Client("Felipe", auction);
            var client2 = new Client("João", auction);
            auction.StartTrading();

            for (int i = 0; i < bidsValues.Length; i++)
            {
                if ((i % 2) == 0)
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
