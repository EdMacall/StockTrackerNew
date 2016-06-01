using StockTrackerNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Infrastructure
{
    public class StockWatchListRepository : GenericRepository<StockWatchList>
    {
        public StockWatchListRepository(ApplicationDbContext db) : base(db) { }

        public StockWatchList Find(int watchlistid, int stockid)
        {
            return _db.Set<StockWatchList>().FirstOrDefault(swl => swl.WatchListId == watchlistid && swl.StockId == stockid);
        }

        public bool Delete(int watchlistid, int stockid)
        {
            StockWatchList stockwatchlist = Find(watchlistid, stockid);

            if (stockwatchlist == null)
            {
                return false;
            }

            _db.Remove(stockwatchlist);
            return true;
        }
    }

    }
