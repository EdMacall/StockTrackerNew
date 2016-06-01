using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Models
{
    public class StockWatchList
    {
        public int         StockId { get; set; }
        [ForeignKey("StockId")]
        public Stock         Stock { get; set; }

        public int     WatchListId { get; set; }
        [ForeignKey("WatchListId")]
        public WatchList WatchList { get; set; }
    }
}
