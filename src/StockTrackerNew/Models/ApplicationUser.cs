using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StockTrackerNew.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int                     UserLevel { get; set; }

        // what is this?
        // public DateTime                EODReport { get; set; }

        public string                  FirstName { get; set; }
        public string                   LastName { get; set; }

        public ICollection<WatchList> WatchLists { get; set; }
        // public ICollection<StopLoss>  StopLosses { get; set; }
    }
}
