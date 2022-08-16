using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCategory.Models
{
    public class Trade : ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }
        public string Category { get; set; }

        public Trade(double value, string clientSector, DateTime nextPaymentDate)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }

        public void CategorizeTrade(DateTime refDate)
        {
            //TODO: There is currently no specific category for trades worth up to 1,000,000.00. This category should be created in the future.
            if (this.NextPaymentDate < refDate.AddDays(-30))
                this.Category = Categories.Expired;
            else
            if (this.Value > 1000000 && this.ClientSector == "Public")
                this.Category = Categories.MediumRisk;
            else
            if (this.Value > 1000000 && this.ClientSector == "Private")
                this.Category = Categories.HighRisk;
        }
    }
}
