using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrackerNew.Models
{
    public class WatchList
    {
        public int                                      Id { get; set; }

        [Required(ErrorMessage = "You must provide a name!")]
        public string                                 Name { get; set; }
        public string                             ImageURL { get; set; }

        public string                    ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser             ApplicationUser { get; set; }

        public ICollection<StockWatchList> StockWatchLists { get; set; }
    }
}
