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
    [Route("api/StopLossFixeds")]
    public class StopLossFixedsController : Controller
    {
        private ApplicationDbContext _context;

        public StopLossFixedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StopLossFixeds
        [HttpGet]
        public IEnumerable<StopLossFixed> GetStopLossFixed()
        {
            return _context.StopLossFixed;
        }

        // GET: api/StopLossFixeds/5
        [HttpGet("{id}", Name = "GetStopLossFixed")]
        public IActionResult GetStopLossFixed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            StopLossFixed stopLossFixed = _context.StopLossFixed.Single(m => m.Id == id);

            if (stopLossFixed == null)
            {
                return HttpNotFound();
            }

            return Ok(stopLossFixed);
        }

        // PUT: api/StopLossFixeds/5
        [HttpPut("{id}")]
        public IActionResult PutStopLossFixed(int id, [FromBody] StopLossFixed stopLossFixed)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != stopLossFixed.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(stopLossFixed).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopLossFixedExists(id))
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

        // POST: api/StopLossFixeds
        [HttpPost]
        public IActionResult PostStopLossFixed([FromBody] StopLossFixed stopLossFixed)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.StopLossFixed.Add(stopLossFixed);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StopLossFixedExists(stopLossFixed.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetStopLossFixed", new { id = stopLossFixed.Id }, stopLossFixed);
        }

        // DELETE: api/StopLossFixeds/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStopLossFixed(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            StopLossFixed stopLossFixed = _context.StopLossFixed.Single(m => m.Id == id);
            if (stopLossFixed == null)
            {
                return HttpNotFound();
            }

            _context.StopLossFixed.Remove(stopLossFixed);
            _context.SaveChanges();

            return Ok(stopLossFixed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StopLossFixedExists(int id)
        {
            return _context.StopLossFixed.Count(e => e.Id == id) > 0;
        }
    }
    */
}