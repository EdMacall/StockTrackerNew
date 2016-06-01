using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Models
{
    public class StopLossRateOfReturnDTO
    {
        public DateTime      StartDate { get; set; }
        public double?      StartPrice { get; set; }
        public double?    RateOfReturn { get; set; }
        public DateTime CalculatedDate { get; set; }

        // Do we need this?
        public double?   CurrenttPrice { get; set; }
    }
}
