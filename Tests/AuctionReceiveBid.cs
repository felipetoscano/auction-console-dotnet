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
        public void DoesNotAllowNewBidsGivenAuctionEnded()
        {
            //Arranje
            var auction = new Auction("TV");
            var client = new Client("João", auction);
            auction.StartTrading();
            auction.ReceiveBid(client, 100);
            auction.ReceiveBid(client, 200);
            auction.ReceiveBid(client, 300);
            auction.EndTrading();

            //Act
            auction.ReceiveBid(client, 400);

            //Assert
            var expected = 3;
            var actual = auction.Bids.Count();

            Assert.Equal(expected, actual);
        }
    }
}
