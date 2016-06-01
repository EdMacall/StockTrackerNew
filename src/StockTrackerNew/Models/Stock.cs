using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Models
{
    public class Stock
    {
        public int                                      Id { get; set; }

        [Required(ErrorMessage = "You must provide a name!")]
        public string                                 Name { get; set; }

        [Required(ErrorMessage = "You must provide a ticker symbol!")]
        public string                         TickerSymbol { get; set; }
        public string                             ImageURL { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Last Price can't be negative!")]
        public double?                           LastPrice { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Today's Openning Price can't be negative!")]
        public double?                           TodayOpen { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Today's High Price can't be negative!")]
        public double?                           TodayHigh { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Today's Low Price can't be negative!")]
        public double?                            TodayLow { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Last Closing Price can't be negative!")]
        public double?                           LastClose { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Volume can't be negative!")]
        public double?                              Volume { get; set; }

        public DateTime?                       LastUpdated { get; set; }

        public bool?                                Follow { get; set; }

        public ICollection<StockWatchList> StockWatchLists { get; set; }

    }
}
