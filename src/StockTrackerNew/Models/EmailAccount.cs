using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Models
{
    public class EmailAccount
    {
        public int              Id { get; set; }
        public string EmailAddress { get; set; }
        public string     Password { get; set; }
        public string          URL { get; set; }
    }
}
