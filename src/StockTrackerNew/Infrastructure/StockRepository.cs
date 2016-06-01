using StockTrackerNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Infrastructure
{
    public class StockRepository : GenericRepository<Stock>
    {
        public StockRepository(ApplicationDbContext db) : base(db) { }
    }
}
