using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Models
{
    public class WatchListDTO
    {
        public int                   Id { get; set; }

        public string              Name { get; set; }
        public string          ImageURL { get; set; }

        public IList<StockDTO> Stocks { get; set; }

        public string ApplicationUserId { get; set; }

        /*
        [ForeignKey("Id")]
        public ApplicationUser ApplicationUser { get; set; }
        */
    }
}
