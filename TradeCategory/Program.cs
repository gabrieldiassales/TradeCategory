using System.IO;
using TradeCategory.Models;
using TradeCategory.Utils;

namespace TradeCategory
{
    class Program
    {
        static List<ITrade> tradeList = new List<ITrade>();
        static DateTime refDate;

        static void Main(string[] args)
        {
            Console.WriteLine(ShowHeader());
            Console.WriteLine("");
            Input();
            Output(tradeList);
        }

        static string ShowHeader()
        {
            return "Trade Category System";
        }

        static void Input()
        {
            int numTrades = 0;
            Utilities utils = new Utilities();

            Console.Write("Input reference date (Format: mm/dd/yyyy):");
            refDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);
            Console.Write("Input number of trades in the portfolio:");
            numTrades = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Input the {numTrades} trade(s) in the portfolio (data for each trade separated by space):");
            Console.WriteLine("[Trade Amount] [Client’s Sector] [Date of next Pending Payment]:");

            for (int i = 0; i < numTrades; i++)
            {
                tradeList.Add(utils.ConvertStringToTrade(Console.ReadLine(), refDate));
            }
        }

        static void Output(List<ITrade> list)
        {
            Console.WriteLine("");
            Console.WriteLine("--> Category of Trades:");

            foreach (ITrade trade in list)
            {
                Console.WriteLine(trade.Category);
            }

        }
    }
}