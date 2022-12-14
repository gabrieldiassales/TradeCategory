using TradeCategory.Models;

namespace TradeCategory.Utils
{
    public class Utilities
    {
        public ITrade ConvertStringToTrade(string text, DateTime refDate)
        {
            string[] data = text.Split(' ');
            double value = double.Parse(data[0]);
            string clientSector = data[1];
            DateTime nextPaymentDate = DateTime.ParseExact(data[2], "MM/dd/yyyy", null);

            ITrade trade = new Trade(value, clientSector, nextPaymentDate);
            trade.CategorizeTrade(refDate);

            return trade;
        }
    }
}
