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
    [Route("api/StopLossTrendLines")]
    public class StopLossTrendLinesController : Controller
    {
        private ApplicationDbContext _context;

        public StopLossTrendLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StopLossTrendLines
        [HttpGet]
        public IEnumerable<StopLossTrendLine> GetStopLossTrendLine()
        {
            return _context.StopLossTrendLine;
        }

        // GET: api/StopLossTrendLines/5
        [HttpGet("{id}", Name = "GetStopLossTrendLine")]
        public IActionResult GetStopLossTrendLine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            StopLossTrendLine stopLossTrendLine = _context.StopLossTrendLine.Single(m => m.Id == id);

            if (stopLossTrendLine == null)
            {
                return HttpNotFound();
            }

            return Ok(stopLossTrendLine);
        }

        // PUT: api/StopLossTrendLines/5
        [HttpPut("{id}")]
        public IActionResult PutStopLossTrendLine(int id, [FromBody] StopLossTrendLine stopLossTrendLine)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != stopLossTrendLine.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(stopLossTrendLine).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopLossTrendLineExists(id))
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

        // POST: api/StopLossTrendLines
        [HttpPost]
        public IActionResult PostStopLossTrendLine([FromBody] StopLossTrendLine stopLossTrendLine)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.StopLossTrendLine.Add(stopLossTrendLine);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StopLossTrendLineExists(stopLossTrendLine.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetStopLossTrendLine", new { id = stopLossTrendLine.Id }, stopLossTrendLine);
        }

        // DELETE: api/StopLossTrendLines/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStopLossTrendLine(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            StopLossTrendLine stopLossTrendLine = _context.StopLossTrendLine.Single(m => m.Id == id);
            if (stopLossTrendLine == null)
            {
                return HttpNotFound();
            }

            _context.StopLossTrendLine.Remove(stopLossTrendLine);
            _context.SaveChanges();

            return Ok(stopLossTrendLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StopLossTrendLineExists(int id)
        {
            return _context.StopLossTrendLine.Count(e => e.Id == id) > 0;
        }
    }
    */
}