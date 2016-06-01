using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using StockTrackerNew.Models;

namespace StockTrackerNew.Controllers
{
    /*
    [Produces("application/json")]
    [Route("api/StopLossTrailings")]
    public class StopLossTrailingsController : Controller
    {
        private ApplicationDbContext _context;

        public StopLossTrailingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StopLossTrailings
        [HttpGet]
        public IEnumerable<StopLossTrailing> GetStopLossTrailing()
        {
            return _context.StopLossTrailing;
        }

        // GET: api/StopLossTrailings/5
        [HttpGet("{id}", Name = "GetStopLossTrailing")]
        public IActionResult GetStopLossTrailing([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            StopLossTrailing stopLossTrailing = _context.StopLossTrailing.Single(m => m.Id == id);

            if (stopLossTrailing == null)
            {
                return HttpNotFound();
            }

            return Ok(stopLossTrailing);
        }

        // PUT: api/StopLossTrailings/5
        [HttpPut("{id}")]
        public IActionResult PutStopLossTrailing(int id, [FromBody] StopLossTrailing stopLossTrailing)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != stopLossTrailing.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(stopLossTrailing).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopLossTrailingExists(id))
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

        // POST: api/StopLossTrailings
        [HttpPost]
        public IActionResult PostStopLossTrailing([FromBody] StopLossTrailing stopLossTrailing)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.StopLossTrailing.Add(stopLossTrailing);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StopLossTrailingExists(stopLossTrailing.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetStopLossTrailing", new { id = stopLossTrailing.Id }, stopLossTrailing);
        }

        // DELETE: api/StopLossTrailings/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStopLossTrailing(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            StopLossTrailing stopLossTrailing = _context.StopLossTrailing.Single(m => m.Id == id);
            if (stopLossTrailing == null)
            {
                return HttpNotFound();
            }

            _context.StopLossTrailing.Remove(stopLossTrailing);
            _context.SaveChanges();

            return Ok(stopLossTrailing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StopLossTrailingExists(int id)
        {
            return _context.StopLossTrailing.Count(e => e.Id == id) > 0;
        }
    }
    */
}