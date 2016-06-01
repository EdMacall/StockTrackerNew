using StockTrackerNew.Infrastructure;
using StockTrackerNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Services
{
    public class WatchListService
    {
        private ApplicationUserRepository _applicationuserrepository;
        // private StockWatchListRepository  _stockwatchlistrepository;
        private WatchListRepository       _watchlistrepository;

        public WatchListService(WatchListRepository watchlistrepository, ApplicationUserRepository applicationuserrepository)
        {
            _watchlistrepository       = watchlistrepository;
            _applicationuserrepository = applicationuserrepository;
        }


        public ICollection<WatchListDTO> GetWatchListList(string currentuser)
        {
            var AppUserId = _applicationuserrepository.FindUserByUserName(currentuser).FirstOrDefault().Id;

            return (from w in _watchlistrepository.List()
                    where AppUserId == w.ApplicationUserId
                    select new WatchListDTO
                    {
                          Id = w.Id,
                        Name = w.Name,
                        ImageURL = w.ImageURL,
                    }).ToList();
        }


        public WatchListDTO GetWatchList(string currentuser, int id)
        {
            var AppUserId = _applicationuserrepository.FindUserByUserName(currentuser).FirstOrDefault().Id;

            WatchListDTO watchlistdto =
                   (from w in _watchlistrepository.List()
                    where AppUserId == w.ApplicationUserId && w.Id == id
                    select new WatchListDTO
                    {
                        Id = w.Id,
                        Name = w.Name,
                        ImageURL = w.ImageURL,
                        ApplicationUserId = w.ApplicationUserId,
                        Stocks = (from swl in w.StockWatchLists
                                  select new StockDTO {
                                       Id = swl.Stock.Id,
                                       Name = swl.Stock.Name,
                                       TickerSymbol = swl.Stock.TickerSymbol,
                                       ImageURL = swl.Stock.ImageURL,
                                       Follow = swl.Stock.Follow,
                                       LastPrice = swl.Stock.LastPrice,
                                       TodayHigh = swl.Stock.TodayHigh,
                                       TodayLow = swl.Stock.TodayLow,
                                       TodayOpen = swl.Stock.TodayOpen,
                                       LastClose = swl.Stock.LastClose,
                                       Volume = swl.Stock.Volume,
                                       LastUpdated = swl.Stock.LastUpdated
                                  }).ToList()
                    }).FirstOrDefault();
            return watchlistdto;
        }


        public void AddWatchList(WatchListDTO watchlistdto)
        {
            WatchList newWatchList = new WatchList
            {
                Name = watchlistdto.Name,
                ApplicationUserId = watchlistdto.ApplicationUserId,
                ImageURL = watchlistdto.ImageURL,
            };

            _watchlistrepository.Add(newWatchList);
            _watchlistrepository.SaveChanges();
        }


        // WatchListDTO must know what the ApplicationUserId is before 
        // entering into here...
        public void EditWatchList(int id, WatchListDTO watchlistdto)
        {
            WatchList dbWatchList = _watchlistrepository.List().First(s => s.Id == id);

            dbWatchList.Name = watchlistdto.Name;
            dbWatchList.ApplicationUserId = watchlistdto.ApplicationUserId;
            dbWatchList.ImageURL = watchlistdto.ImageURL;

            _watchlistrepository.SaveChanges();
        }


        public bool Exists(string currentuser, WatchListDTO watchlistdto)
        {
            var AppUserId = _applicationuserrepository.FindUserByUserName(currentuser).FirstOrDefault().Id;

            watchlistdto.ApplicationUserId = AppUserId;

            WatchList result = (from w in _watchlistrepository.List()
                                where (w.Name == watchlistdto.Name) &&
                                      (w.ApplicationUserId == watchlistdto.ApplicationUserId)
                                select w).FirstOrDefault();

            if (result != null)
            {
                return true;
            }

            return false;
        }

        public bool Exists(string currentuser, int id)
        {
            var AppUserId = _applicationuserrepository.FindUserByUserName(currentuser).FirstOrDefault().Id;

            /*
            watchlistdto.ApplicationUserId = AppUserId;

            WatchList result = (from w in _watchlistrepository.List()
                                where (w.Name == watchlistdto.Name) &&
                                      (w.ApplicationUserId == watchlistdto.ApplicationUserId)
                                select w).FirstOrDefault();


            if (result != null)
            {
                return true;
            }
            */

            return false;
        }

        public bool Exists(int id)
        {
            // var AppUserId = _applicationuserrepository.FindUserByUserName(currentuser).FirstOrDefault().Id;

            // watchlistdto.ApplicationUserId = AppUserId;

            WatchList result = (from w in _watchlistrepository.List()
                                where (w.Id == id)
                                select w).FirstOrDefault();

            if (result != null)
            {
                return true;
            }

            return false;
        }

        public void DeleteWatchList(WatchListDTO watchlistdto)
        {
            /*
            // This probably doesn't work,  because we tried to
            // create a new watchlist with the same information and
            // delete the new watchlist,  instead of getting the existing
            // watchlist and deleting it.
            // So did we need to create a new DTO to do this?
            // We probably only should have needed an Id number to do this.
            WatchList watchlist = new WatchList {
                Id = watchlistdto.Id,
                Name = watchlistdto.Name,
                ImageURL = watchlistdto.ImageURL,
                ApplicationUserId = watchlistdto.ApplicationUserId,
                ApplicationUser = (from au in _applicationuserrepository.List()
                                   where au.Id == watchlistdto.ApplicationUserId
                                   select au).FirstOrDefault()
            };

            _watchlistrepository.Delete(watchlist);
            */

            _watchlistrepository.Delete(watchlistdto.Id);
            _watchlistrepository.SaveChanges();
        }
    }
}
