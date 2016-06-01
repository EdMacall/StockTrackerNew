using StockTrackerNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Infrastructure
{
    public class WatchListRepository : GenericRepository<WatchList>
    {
        public WatchListRepository(ApplicationDbContext db) : base(db) { }

        public WatchList Find(int id)
        {
            return _db.Set<WatchList>().FirstOrDefault(wl => wl.Id == id);
        }

        public IQueryable<StockWatchList> FindStocks(int id, string currentUser)
        {
            return from swl in _db.StockWatchLists
                   where swl.WatchListId == id && swl.WatchList.ApplicationUser.UserName == currentUser
                   select swl;
        }

        public bool Delete(int id)
        {
            WatchList watchlist = Find(id);

            if(watchlist == null)
            {
                return false;
            }

            _db.Remove(watchlist);
            return true;
        }
    }
}
