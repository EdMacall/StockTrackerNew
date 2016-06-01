using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using StockTrackerNew.Models;

namespace StockTrackerNew.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StockWatchList>().HasKey(x => new { x.StockId, x.WatchListId });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Stock>                               Stock { get; set; }
        public DbSet<WatchList>                       WatchList { get; set; }
        public DbSet<StockWatchList>            StockWatchLists { get; set; }
        public DbSet<ApplicationUser>          ApplicationUsers { get; set; }
        // public DbSet<StopLossFixed>               StopLossFixed { get; set; }
        // public DbSet<StopLossRateOfReturn> StopLossRateOfReturn { get; set; }
        // public DbSet<StopLossTrailing>         StopLossTrailing { get; set; }
        // public DbSet<StopLossTrendLine>       StopLossTrendLine { get; set; }
    }
}
