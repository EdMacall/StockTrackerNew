using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using StockTrackerNew.Models;
using StockTrackerNew.Services;

namespace StockTrackerNew.Controllers
{
    [Produces("application/json")]
    [Route("api/Stocks")]
    public class StocksController : Controller
    {
        private StockService _stockservice;

        public StocksController(StockService stockservice)
        {
            _stockservice = stockservice;
        }

        // GET: api/Stocks
        [HttpGet]
        public ICollection<StockDTO> GetStocks()
        {
            return _stockservice.GetStockList().ToList();
        }


        // GET: api/Stocks
        [HttpGet("watchlists/{id}")]
        public ICollection<StockDTO> GetStocksMinusWatchList(int id)
        {
            return _stockservice.GetStockListMinusWatchList(id, User.Identity.Name);
        }


        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var stockdto = _stockservice.GetStockList().First(s => s.Id == id);

            if(stockdto != null)
            {
                return Ok(stockdto);
            }

            return HttpNotFound();
        }
        
        // GET: api/Stocks/5
        // [HttpGet("update/{ticker}")]
        // public IActionResult GetUpdate(string ticker)
        [HttpGet("update/{ticker}")]
        public IActionResult GetUpdate(string ticker)
        {
            StockDTO stockdto = _stockservice.UpdateStock(ticker);
            if (stockdto != null)
            {
                return Ok(stockdto);
            }

            return HttpBadRequest();
        }

        // PUT: api/Stocks/5
        [HttpPut("{id}")]
        public IActionResult PutStock(int id, [FromBody] StockDTO stockdto)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            /*
            if (id != stock.Id)
            {
                return HttpBadRequest();
            }
            */

            _stockservice.EditStock(id, stockdto);

            return Ok(stockdto);

            // return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Stocks
        [HttpPost]
        public IActionResult PostStock([FromBody] StockDTO stockdto)
        {
            if (ModelState.IsValid && !_stockservice.Exists(stockdto.TickerSymbol))
            {
                _stockservice.AddStock(stockdto);
                return Ok(stockdto);
            }

            return HttpBadRequest(ModelState);
        }

        /*
        // GET: api/Stocks/5
        [HttpGet("{id}", Name = "GetStock")]
        public IActionResult GetStock([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Stock stock = _context.Stock.Single(m => m.Id == id);

            if (stock == null)
            {
                return HttpNotFound();
            }

            return Ok(stock);
        }

        // PUT: api/Stocks/5
        [HttpPut("{id}")]
        public IActionResult PutStock(int id, [FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != stock.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Stocks
        [HttpPost]
        public IActionResult PostStock([FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Stock.Add(stock);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StockExists(stock.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetStock", new { id = stock.Id }, stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStock(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Stock stock = _context.Stock.Single(m => m.Id == id);
            if (stock == null)
            {
                return HttpNotFound();
            }

            _context.Stock.Remove(stock);
            _context.SaveChanges();

            return Ok(stock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockExists(int id)
        {
            return _context.Stock.Count(e => e.Id == id) > 0;
        }
        */
    }
}