using TradeCategory.Models;
using TradeCategory.Utils;

namespace TradeCategory.Test
{
    public class TradeTests
    {
        [Fact]
        public void TestCategorizeTradeExpired()
        {
            //Arrange
            List<ITrade> tradeList = new List<ITrade>();
            DateTime refDate = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", null);
            ITrade trade = new Trade(400000, "Public", DateTime.ParseExact("07/01/2020", "MM/dd/yyyy", null), false);
            tradeList.Add(trade);

            //Act
            trade.CategorizeTrade(refDate);

            //Assert
            Assert.Equal("EXPIRED", trade.Category);
        }

        [Fact]
        public void TestCategorizeTradeHighRisk()
        {
            //Arrange
            List<ITrade> tradeList = new List<ITrade>();
            DateTime refDate = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", null);
            ITrade trade = new Trade(2000000, "Private", DateTime.ParseExact("12/29/2025", "MM/dd/yyyy", null), false);
            tradeList.Add(trade);

            //Act
            trade.CategorizeTrade(refDate);

            //Assert
            Assert.Equal("HIGHRISK", trade.Category);
        }

        [Fact]
        public void TestCategorizeTradeMediumRisk()
        {
            //Arrange
            List<ITrade> tradeList = new List<ITrade>();
            DateTime refDate = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", null);
            ITrade trade = new Trade(5000000, "Public", DateTime.ParseExact("01/02/2024", "MM/dd/yyyy", null), false);
            tradeList.Add(trade);

            //Act
            trade.CategorizeTrade(refDate);

            //Assert
            Assert.Equal("MEDIUMRISK", trade.Category);
        }

        [Fact]
        public void TestCategorizeTradePep()
        {
            //Arrange
            List<ITrade> tradeList = new List<ITrade>();
            DateTime refDate = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", null);
            ITrade trade = new Trade(5000000, "Public", DateTime.ParseExact("01/02/2024", "MM/dd/yyyy", null), true);
            tradeList.Add(trade);

            //Act
            trade.CategorizeTrade(refDate);

            //Assert
            Assert.Equal("PEP", trade.Category);
        }

        [Fact]
        public void TestConvertStringToTrade()
        {
            //Arrange            
            DateTime refDate = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", null);
            Utilities utils = new Utilities();

            //Act
            ITrade trade = utils.ConvertStringToTrade("5000000 Public 01/02/2024 false", refDate);

            //Assert
            Assert.Equal("Public", trade.ClientSector);
        }
    }
}