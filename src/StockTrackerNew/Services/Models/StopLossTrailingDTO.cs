using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Models
{
    public class StopLossTrailingDTO
    {
        // Start date that stoploss was being tracked from
        // usually from a purchase date
        // so as to not have stop loss be calculated upon some 
        // previous high,  which is way higher than any recent high
        public DateTime            StartDate { get; set; }
        public double? StrikePercentFromHigh { get; set; }
        public double?              LastHigh { get; set; }
        public DateTime         LastHighDate { get; set; }
    }
}
