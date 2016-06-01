using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Models
{
    public class StockDTO
    {   
        public int                 Id { get; set; }
        public string            Name { get; set; }
        public string    TickerSymbol { get; set; }
        public string        ImageURL { get; set; }
        public bool?           Follow { get; set; }
        public double?      LastPrice { get; set; }
        public double?      TodayHigh { get; set; }
        public double?       TodayLow { get; set; }
        public double?      TodayOpen { get; set; }
        public double?      LastClose { get; set; }
        public double?         Volume { get; set; }
        public DateTime?  LastUpdated { get; set; }

        /*
        public string  WatchListId { get; set; }
        [ForeignKey("Id")]
        public WatchList WatchList { get; set; }
        */
    }
}
