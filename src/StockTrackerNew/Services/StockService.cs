using CsvHelper;
using CsvHelper.Configuration;
using StockTrackerNew.Infrastructure;
using StockTrackerNew.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockTrackerNew.Services
{
    public class StockService
    {
        private StockRepository _stockrepository;
        private WatchListRepository _watchlistrepository;

        public StockService(StockRepository stockrepository, WatchListRepository watchlistrepository)
        {
            _stockrepository     = stockrepository;
            _watchlistrepository = watchlistrepository;
        }

        public ICollection<StockDTO> GetStockList()
        {
            return (from s in _stockrepository.List()
                    select new StockDTO
                    {
                        Id = s.Id,
                        Name = s.Name,
                        TickerSymbol = s.TickerSymbol,
                        ImageURL = s.ImageURL,
                        Follow = s.Follow,
                        LastPrice = s.LastPrice,
                        TodayHigh = s.TodayHigh,
                        TodayLow = s.TodayLow,
                        TodayOpen = s.TodayOpen,
                        LastClose = s.LastClose,
                        Volume = s.Volume,
                        LastUpdated = s.LastUpdated
                    }).ToList();
        }

        public ICollection<StockDTO> GetStockListMinusWatchList(int id, string currentUser)
        {
            ICollection<string> stocks = (from swl in _watchlistrepository.FindStocks(id, currentUser)
                                          select swl.Stock.TickerSymbol).ToList();

            return (from s in _stockrepository.List()
                    where !stocks.Contains(s.TickerSymbol)
                    select new StockDTO
                    {
                        Id = s.Id,
                        Name = s.Name,
                        TickerSymbol = s.TickerSymbol,
                        ImageURL = s.ImageURL,
                        Follow = s.Follow,
                        LastPrice = s.LastPrice,
                        TodayHigh = s.TodayHigh,
                        TodayLow = s.TodayLow,
                        TodayOpen = s.TodayOpen,
                        LastClose = s.LastClose,
                        Volume = s.Volume,
                        LastUpdated = s.LastUpdated
                    }).ToList();
        }

        public void AddStock(StockDTO stock)
        {
            Stock newStock = new Stock
            {
                Name = stock.Name,
                TickerSymbol = stock.TickerSymbol,
                ImageURL = stock.ImageURL,
                LastPrice = stock.LastPrice,
                TodayOpen = stock.TodayOpen,
                TodayHigh = stock.TodayHigh,
                TodayLow = stock.TodayLow,
                LastClose = stock.LastClose,
                Volume = stock.Volume,
                LastUpdated = DateTime.Now,
                Follow = stock.Follow
            };

            _stockrepository.Add(newStock);
            _stockrepository.SaveChanges();
        }

        public void EditStock(int id, StockDTO stockdto)
        {
            Stock dbStock = _stockrepository.List().First(s => s.Id == id);

            dbStock.Name         = stockdto.Name;
            dbStock.TickerSymbol = stockdto.TickerSymbol;
            dbStock.ImageURL     = stockdto.ImageURL;
            dbStock.LastPrice    = stockdto.LastPrice;
            dbStock.TodayOpen    = stockdto.TodayOpen;
            dbStock.TodayHigh    = stockdto.TodayHigh;
            dbStock.TodayLow     = stockdto.TodayLow;
            dbStock.LastClose    = stockdto.LastClose;
            dbStock.Volume       = stockdto.Volume;
            dbStock.LastUpdated  = DateTime.Now;
            dbStock.Follow       = stockdto.Follow;

            _stockrepository.SaveChanges();
        }

        public StockDTO UpdateStock(string ticker)
        {
            string csvData;
            string URLString = "http://finance.yahoo.com/d/quotes.csv?s=" + ticker + "&f=snbaopl1ghv";

            // using (WebClient web = new WebClient())
            using (HttpClient web = new HttpClient())
            {
                // csvData = web.DownloadString("http://finance.yahoo.com/d/quotes.csv?s=AAPL+GOOG+MSFT&f=snbaopl1");
                // csvData = web.GetStringAsync("http://finance.yahoo.com/d/quotes.csv?s=AAPL+GOOG+MSFT&f=snbaopl1ghv").Result;
                csvData = web.GetStringAsync(URLString).Result;
            }

            csvData = "TickerSymbol,Name,Bid,Ask,TodayOpen,LastClose,LastPrice,TodayLow,TodayHigh,Volume\n" + csvData;

            // Numbers with N/A result cause the program to crash here...
            StockDTO stockdto = new CsvReader(new StringReader(csvData), new CsvConfiguration()
            {
                WillThrowOnMissingField = false
            }).GetRecords<StockDTO>().FirstOrDefault();

            // stockdto.LastUpdated = DateTime.Now;

            if(Exists(ticker))
            {
                UpdateStock(stockdto);
            }

            return stockdto;
        }

        public void UpdateStocks(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            string csvData;
            string ticker = "AAPL";

            ICollection<string> stocks = (from s in _stockrepository.List()
                                          where s.Follow == true
                                          select s.TickerSymbol).ToList();

            if (stocks == null || stocks.Count() == 0)
            {
                return;
            }

            // string URLString = "http://finance.yahoo.com/d/quotes.csv?s=" + ticker + "&f=snbaopl1ghv";

            bool first = true;

            StringBuilder sb = new StringBuilder("http://finance.yahoo.com/d/quotes.csv?s=");

            foreach(string stock in stocks)
            {
                if (first)
                {
                    sb.Append(stock);
                    first = false;
                }
                else
                {
                    sb.Append("+" + stock);
                }
            }

            sb.Append("&f=snbaopl1ghv");

            string URLString = sb.ToString();

            using (HttpClient web = new HttpClient())
            {
                csvData = web.GetStringAsync(URLString).Result;
            }

            csvData = "TickerSymbol,Name,Bid,Ask,TodayOpen,LastClose,LastPrice,TodayLow,TodayHigh,Volume\n" + csvData;

            // Numbers with N/A result cause the program to crash here...
            ICollection<StockDTO> stockdtos = new CsvReader(new StringReader(csvData), new CsvConfiguration()
            {
                WillThrowOnMissingField = false
            }).GetRecords<StockDTO>().ToList();

            if (Exists(ticker))
            {
                UpdateStocks(stockdtos);
            }

            // return stockdto;
        }

        public void UpdateStock(StockDTO stockdto)
        {
            Stock dbStock = _stockrepository.List().First(s => s.TickerSymbol == stockdto.TickerSymbol);

            dbStock.Name = stockdto.Name;
            dbStock.LastPrice = stockdto.LastPrice;
            dbStock.TodayOpen = stockdto.TodayOpen;
            dbStock.TodayHigh = stockdto.TodayHigh;
            dbStock.TodayLow = stockdto.TodayLow;
            dbStock.LastClose = stockdto.LastClose;
            dbStock.Volume = stockdto.Volume;
            dbStock.LastUpdated = stockdto.LastUpdated = DateTime.Now; ;

            _stockrepository.SaveChanges();
        }

        public void UpdateStocks(ICollection<StockDTO> stockdtos)
        {
            Stock dbStock;

            foreach (var stockdto in stockdtos)
            {
                dbStock = _stockrepository.List().First(s => s.TickerSymbol == stockdto.TickerSymbol);

                dbStock.Name = stockdto.Name;
                dbStock.LastPrice = stockdto.LastPrice;
                dbStock.TodayOpen = stockdto.TodayOpen;
                dbStock.TodayHigh = stockdto.TodayHigh;
                dbStock.TodayLow = stockdto.TodayLow;
                dbStock.LastClose = stockdto.LastClose;
                dbStock.Volume = stockdto.Volume;
                dbStock.LastUpdated = stockdto.LastUpdated = DateTime.Now;

                _stockrepository.SaveChanges();
            }
        }

        public bool Exists(string tickersymbol)
        {
            if (_stockrepository.Query<Stock>().FirstOrDefault(s => s.TickerSymbol == tickersymbol) != null)
            {
                return true;
            }

            return false;
        }

        public bool Exists(int id)
        {
            if (_stockrepository.Query<Stock>().FirstOrDefault(s => s.Id == id) != null)
            {
                return true;
            }

            return false;
        }
    }
}
