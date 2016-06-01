using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Models
{
    public class DataServiceAccount
    {
        public int            Id { get; set; }
        public int          User { get; set; }
        public string   UserName { get; set; }
        public string   Password { get; set; }
        public string        Url { get; set; }
        public bool  AbleToLogon { get; set; }
    }
}
