using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using StockTrackerNew.Models;
using StockTrackerNew.Services;
using System;

namespace StockTrackerNew.Controllers
{
    [Produces("application/json")]
    [Route("api/WatchLists")]
    public class WatchListsController : Controller
    {
        private StockService          _stockservice;
        private StockWatchListService _stockwatchlistservice;
        private WatchListService      _watchlistservice;

        public WatchListsController(WatchListService watchlistservice,
                                    StockWatchListService stockwatchlistservice,
                                    StockService stockservice)
        {
            _watchlistservice      = watchlistservice;
            _stockwatchlistservice = stockwatchlistservice;
            _stockservice          = stockservice;
        }


        // GET: api/WatchLists
        [HttpGet]
        [Authorize]
        public ICollection<WatchListDTO> GetWatchLists()
        {
            return _watchlistservice.GetWatchListList(User.Identity.Name).ToList();
        }


        // GET: api/WatchLists/5
        [HttpGet("{id}", Name = "GetWatchList")]
        public IActionResult GetWatchList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            WatchListDTO watchlistdto = _watchlistservice.GetWatchList(User.Identity.Name, id);

            if (watchlistdto == null)
            {
                return HttpNotFound();
            }

            return Ok(watchlistdto);
        }

        /*
        // GET: api/WatchLists/5
        [HttpGet("StockList/{id}", Name = "GetWatchList")]
        public IActionResult GetStockList([FromRoute] int id)
        {
            return HttpBadRequest(ModelState);

            /*
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            WatchListDTO watchListdto = _watchlistservice.GetWatchList(User.Identity.Name, id);

            if (watchListdto == null)
            {
                return HttpNotFound();
            }

            return Ok(watchListdto);
            */
            /*
        }
        */

        // POST: api/watchlists
        [HttpPost]
        public IActionResult PostStock([FromBody] WatchListDTO watchlistdto)
        {
            if (ModelState.IsValid && !_watchlistservice.Exists(User.Identity.Name, watchlistdto))
            {
                _watchlistservice.AddWatchList(watchlistdto);
                return Ok(watchlistdto);
            }

            return HttpBadRequest(ModelState);
        }


        // POST: api/watchlists/addstock/5, stockid
        [HttpPost("addstock/{id}")]
        public IActionResult PostStockToWatchList(int id, [FromBody] int stockid)
        {
            // verify watchlist exists
            // verify stock exists
            if(!_watchlistservice.Exists(id) || !_stockservice.Exists(stockid))
            {
                return HttpNotFound();
            }

            // verify authorized
            WatchListDTO watchlistdto = _watchlistservice.GetWatchList(User.Identity.Name, id);

            if (watchlistdto == null)
            {
                return HttpUnauthorized();
            }

            if (ModelState.IsValid)
            {
                // This is not right
                _stockwatchlistservice.AddStockToWatchList(id, stockid);

                ICollection<StockDTO> stockdto = _stockservice.GetStockListMinusWatchList(id, User.Identity.Name);
                return Ok(stockdto);
            }

            return HttpBadRequest(ModelState);
        }


        // DELETE: api/WatchLists/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWatchList(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (!_watchlistservice.Exists(id))
            {
                return HttpNotFound();
            }

            WatchListDTO watchlistdto = _watchlistservice.GetWatchList(User.Identity.Name, id);

            // this isn't right
            // is this the right way to do this?
            // to create a DTO to find out if the user
            // is authorized?
            if (watchlistdto == null)
            {
                return HttpUnauthorized();
            }

            _watchlistservice.DeleteWatchList(watchlistdto);

            return Ok(GetWatchLists());
        }


        // DELETE: api/WatchLists/stock/5, stockid
        [HttpPost("stock/{id}")]
        public IActionResult DeleteStockWatchList(int id, [FromBody] int stockid)
        {
            if (!ModelState.IsValid)
            {
                // return HttpBadRequest("You're all screwed up...");
                return HttpBadRequest(ModelState);
            }

            // Fix this.
            if (!_stockwatchlistservice.Exists(id, stockid))
            {
                return HttpNotFound();
            }

            // Authorized
            WatchListDTO watchlistdto = _watchlistservice.GetWatchList(User.Identity.Name, id);

            // this isn't right
            // is this the right way to do this?
            // to create a DTO to find out if the user
            // is authorized?
            if (watchlistdto == null)
            {
                return HttpUnauthorized();
            }

            _stockwatchlistservice.DeleteStockWatchList(id, stockid);

            return Ok(GetWatchList(id));
        }


        /*
        // DELETE: api/WatchLists/stock/5
        [HttpDelete("stock/{id}")]
        public IActionResult DeleteStockFromWatchList(int id, int stockid)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            WatchListDTO watchlistdto = _watchlistservice.Single(m => m.Id == id);
            if (watchlistdto == null)
            {
                return HttpNotFound();
            }

            _watchlistrepository.Remove(watchlistdto);
            _watchlistrepository.SaveChanges();

            return Ok(watchlistdto);
        }
        */

        /*
        // GET: api/WatchLists/5
        [HttpGet("{id}", Name = "GetWatchList")]
        public IActionResult GetWatchList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            WatchList watchList = _context.WatchList.Single(m => m.Id == id);

            if (watchList == null)
            {
                return HttpNotFound();
            }

            return Ok(watchList);
        }

        // PUT: api/WatchLists/5
        [HttpPut("{id}")]
        public IActionResult PutWatchList(int id, [FromBody] WatchList watchList)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != watchList.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(watchList).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchListExists(id))
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

        // POST: api/WatchLists
        [HttpPost]
        public IActionResult PostWatchList([FromBody] WatchList watchList)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.WatchList.Add(watchList);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WatchListExists(watchList.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetWatchList", new { id = watchList.Id }, watchList);
        }

        // DELETE: api/WatchLists/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWatchList(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            WatchList watchList = _context.WatchList.Single(m => m.Id == id);
            if (watchList == null)
            {
                return HttpNotFound();
            }

            _context.WatchList.Remove(watchList);
            _context.SaveChanges();

            return Ok(watchList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WatchListExists(int id)
        {
            return _context.WatchList.Count(e => e.Id == id) > 0;
        }
        */
    }
}