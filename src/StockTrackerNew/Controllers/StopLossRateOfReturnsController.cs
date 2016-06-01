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
    [Route("api/StopLossRateOfReturns")]
    public class StopLossRateOfReturnsController : Controller
    {
        private ApplicationDbContext _context;

        public StopLossRateOfReturnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StopLossRateOfReturns
        [HttpGet]
        public IEnumerable<StopLossRateOfReturn> GetStopLossRateOfReturn()
        {
            return _context.StopLossRateOfReturn;
        }

        // GET: api/StopLossRateOfReturns/5
        [HttpGet("{id}", Name = "GetStopLossRateOfReturn")]
        public IActionResult GetStopLossRateOfReturn([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            StopLossRateOfReturn stopLossRateOfReturn = _context.StopLossRateOfReturn.Single(m => m.Id == id);

            if (stopLossRateOfReturn == null)
            {
                return HttpNotFound();
            }

            return Ok(stopLossRateOfReturn);
        }

        // PUT: api/StopLossRateOfReturns/5
        [HttpPut("{id}")]
        public IActionResult PutStopLossRateOfReturn(int id, [FromBody] StopLossRateOfReturn stopLossRateOfReturn)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != stopLossRateOfReturn.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(stopLossRateOfReturn).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopLossRateOfReturnExists(id))
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

        // POST: api/StopLossRateOfReturns
        [HttpPost]
        public IActionResult PostStopLossRateOfReturn([FromBody] StopLossRateOfReturn stopLossRateOfReturn)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.StopLossRateOfReturn.Add(stopLossRateOfReturn);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StopLossRateOfReturnExists(stopLossRateOfReturn.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetStopLossRateOfReturn", new { id = stopLossRateOfReturn.Id }, stopLossRateOfReturn);
        }

        // DELETE: api/StopLossRateOfReturns/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStopLossRateOfReturn(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            StopLossRateOfReturn stopLossRateOfReturn = _context.StopLossRateOfReturn.Single(m => m.Id == id);
            if (stopLossRateOfReturn == null)
            {
                return HttpNotFound();
            }

            _context.StopLossRateOfReturn.Remove(stopLossRateOfReturn);
            _context.SaveChanges();

            return Ok(stopLossRateOfReturn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StopLossRateOfReturnExists(int id)
        {
            return _context.StopLossRateOfReturn.Count(e => e.Id == id) > 0;
        }
    }
    */
}