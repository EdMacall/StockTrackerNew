using StockTrackerNew.Infrastructure;
using StockTrackerNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Services
{
    public class StockWatchListService
    {
        private StockWatchListRepository _stockwatchlistrepository;

        public StockWatchListService(StockWatchListRepository stockwatchlistrepository)
        {
            _stockwatchlistrepository = stockwatchlistrepository;
        }

        public void AddStockToWatchList(int watchlistid, int stockid)
        {
            StockWatchList newStockWatchList = new StockWatchList
            {
                WatchListId = watchlistid,
                StockId = stockid
            };

            _stockwatchlistrepository.Add(newStockWatchList);
            _stockwatchlistrepository.SaveChanges();
        }

        public void DeleteStockWatchList(int watchlistid, int stockid)
        {
            _stockwatchlistrepository.Delete(watchlistid, stockid);
            _stockwatchlistrepository.SaveChanges();
        }

        public bool Exists(int watchlistid, int stockid)
        {
            StockWatchList result = (from swl in _stockwatchlistrepository.List()
                                where (swl.WatchListId == watchlistid && swl.StockId == stockid)
                                select swl).FirstOrDefault();

            if (result != null)
            {
                return true;
            }

            return false;
        }
    }
}
