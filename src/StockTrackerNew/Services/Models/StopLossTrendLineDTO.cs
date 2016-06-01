using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Models
{
    public class StopLossTrendLineDTO
    {
        public DateTime      StartDate { get; set; }
        public double?      StartPrice { get; set; }
        public DateTime        EndDate { get; set; }
        public double?        EndPrice { get; set; }
        public DateTime CalculatedDate { get; set; }

        // Do we need this?
        public double? CalculatedPrice { get; set; }
    }
}
