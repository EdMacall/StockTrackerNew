using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using StockTrackerNew.Infrastructure;
using System.Threading;

namespace StockTrackerNew.Models
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userRepo = new ApplicationUserRepository(context);
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            context.Database.Migrate();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen",
                    FirstName = "Stephen",
                    LastName = "Walther",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure EdMacall (IsAdmin)
            var edmacall = await userManager.FindByNameAsync("EdMacall");
            if (edmacall == null)
            {
                // create user
                edmacall = new ApplicationUser
                {
                    UserName = "EdMacall",
                    FirstName = "Ed",
                    LastName = "Macall",
                    Email = "irvedwmac@aol.com"
                };
                await userManager.CreateAsync(edmacall, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(edmacall, new Claim("IsAdmin", "true"));
            }

            // Ensure Eric (IsAdmin)
            var eric = await userManager.FindByNameAsync("Eric");
            if (eric == null)
            {
                // create user
                eric = new ApplicationUser
                {
                    UserName = "Eric",
                    FirstName = "Eric",
                    LastName = "Siebeneich",
                    Email = "irvedwmac@aol.com"
                };
                await userManager.CreateAsync(eric, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(eric, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike",
                    FirstName = "Mike",
                    LastName = "",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            // Ensure Gerry (not IsAdmin)
            var gerry = await userManager.FindByNameAsync("Gerry");
            if (gerry == null)
            {
                // create user
                gerry = new ApplicationUser
                {
                    UserName = "Gerry",
                    FirstName = "Gerry",
                    LastName = "Miller",
                    Email = "irvedwmac@aaol.com"
                };
                await userManager.CreateAsync(gerry, "Secret123!");
            }

            // Ensure Carol (not IsAdmin)
            var carol = await userManager.FindByNameAsync("Carol");
            if (carol == null)
            {
                // create user
                carol = new ApplicationUser
                {
                    UserName = "Carol",
                    FirstName = "Carol",
                    LastName = "Prygo",
                    Email = "irvedwmac@aol.com"
                };
                await userManager.CreateAsync(carol, "Secret123!");
            }

            // Ensure Harry (not IsAdmin)
            var harry = await userManager.FindByNameAsync("Harry");
            if (harry == null)
            {
                // create user
                harry = new ApplicationUser
                {
                    UserName = "Harry",
                    FirstName = "Harry",
                    LastName = "Adams",
                    Email = "irvedwmac@aol.com"
                };
                await userManager.CreateAsync(harry, "Secret123!");
            }

            // Ensure MikeO (not IsAdmin)
            var mikeo = await userManager.FindByNameAsync("MikeO");
            if (mikeo == null)
            {
                // create user
                mikeo = new ApplicationUser
                {
                    UserName = "MikeO",
                    FirstName = "Mike",
                    LastName = "OReilly",
                    Email = "irvedwmac@aol.com"
                };
                await userManager.CreateAsync(mikeo, "Secret123!");
            }

            var stocks = new List<Stock>() {
                new Stock
                {
                    TickerSymbol = "AAN",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "AAPL",
                    Follow = true
                },
                new Stock
                {
                    TickerSymbol = "AEIS",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "AET",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ALK",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "AMAG",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ANCX",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ANTM",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ATI",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ATML",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ATVI",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "AVGO",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "AWK",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "AZO",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "BCR",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "BEAT",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "BNCN",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "BPT",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "BRCM",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "BRKB",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "CALM",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "CI",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "CMS",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "CNC",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "COR",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "CREE",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "CRM",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "CTL",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "CTSH",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "CVS",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "DDD",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "DHI",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "DIS",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "EBS",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ED",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "EEM",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ELS",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "EXR",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "FIZZ",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "FL",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "FXI",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GB",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GE",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GILD",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GIS",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GLAD",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GLOP",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GPN",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GPOR",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GPRE",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GS",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "GTY",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "HBAN",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "HIMX",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ICUI",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ITC",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "IYT",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "JAZZ",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "KKR",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "KMI",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "KR",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "LANC",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "LEG",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "LUV",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "LVS",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "MA",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "MATW",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "MBT",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "MDVN",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "MHK",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "MO",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "MXIM",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "NAT",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "NBIX",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "NEM",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "NFLX",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "NHTC",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "NI",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "NICE",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "NKE",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "NOC",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "NTES",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "O",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "OKE",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "OLED",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "OME",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ORIT",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ORLY",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "OTEX",
                    Follow = false
                },

                new Stock
                {
                    TickerSymbol = "OZRK",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "PGR",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "PSA",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "RBA",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "SEE",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "SHI",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "SIAF",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "SLP",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "SPXC",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "STZ",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "SWHC",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "SWKS",
                    Follow = false
                },

                new Stock
                {
                    TickerSymbol = "TSN",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "UA",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ULTA",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "UNP",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "UPL",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "URBN",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "USAK",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "USCR",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "VLO",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "VRX",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "VZ",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "WETF",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "XLE",
                    Follow = false
                },

                new Stock
                {
                    TickerSymbol = "XRS",
                    Follow = false
                },
                new Stock
                {
                    TickerSymbol = "ZINC",
                    Follow = false
                }
            };


            AddOrUpdate(stocks, context, (s, db) => s.TickerSymbol == db.TickerSymbol);

            /*
            TimerCallback cb = new TimerCallback((e) =>
            {
                string text = "text";
                Console.WriteLine(text);
            });

            System.Threading.Timer timer = new System.Threading.Timer(cb, null, 10000, 10000);
            */


            var watchlists = new List<WatchList>() {
                new WatchList
                {
                    Name = "MyWatchList",
                    ApplicationUserId = userRepo.FindUserByName("EdMacall").FirstOrDefault().Id
                },
                new WatchList
                {
                    Name = "CCIC",
                    ApplicationUserId = userRepo.FindUserByName("EdMacall").FirstOrDefault().Id
                    
                }
            };
            var AUI = userRepo.FindUserByName("EdMacall").FirstOrDefault().Id;
            Console.WriteLine("Ed Macalls ApplicationUserId is " + AUI + ".");

            AddOrUpdate(watchlists, context, (w, db) => w.ApplicationUserId == db.ApplicationUserId && w.Name == db.Name);

            var stockwatchlists = new List<StockWatchList>() {
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "AAPL").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "MyWatchList").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "AAPL").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "GE").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "MyWatchList").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "NEM").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "STZ").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "XRS").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "COR").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "AWK").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "O").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "GTY").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "USCR").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "ED").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "SPXC").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "ATVI").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "FIZZ").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "GLOP").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "MBT").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "MDVN").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
                new StockWatchList
                {
                    StockId = context.Stock.FirstOrDefault(t => t.TickerSymbol == "OKE").Id,
                    WatchListId = context.WatchList.FirstOrDefault(t => t.Name == "CCIC").Id
                },
            };

            AddOrUpdate(stockwatchlists, context, (swl, db) => swl.StockId == db.StockId && swl.WatchListId == db.WatchListId);


        }

        public static void AddOrUpdate<B>(IList<B> list, ApplicationDbContext db, Func<B, B, bool> func) where B : class
        {
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                Func<B, bool> newFunc = b => func(item, b);
                var dbItem = db.Set<B>().FirstOrDefault(newFunc);

                if (dbItem == null)
                {
                    db.Set<B>().Add(item);
                }
                else
                {
                    list[i] = dbItem;
                }
            }

            db.SaveChanges();
        }
    }
}
