using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StockTrackerNew.Models;
using StockTrackerNew.Services;
using Newtonsoft.Json.Serialization;
using StockTrackerNew.Infrastructure;


namespace StockTrackerNew
{
    public class Startup
    {
        public static AutoResetEvent autoEvent;

        StatusChecker statusChecker;

        StockService stockService;

        public static TimerCallback tcb;

        public static System.Threading.Timer timer;

        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            // convert Pascal to Camel
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
            });


            // add security policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim("IsAdmin"));
            });

            // Repositories
            services.AddScoped<StockRepository>();
            services.AddScoped<StockWatchListRepository>();
            services.AddScoped<WatchListRepository>();
            services.AddScoped<ApplicationUserRepository>();
            // services.AddScoped<StopLossFixedRepository>();
            // services.AddScoped<StopLossRateOfReturnRepository>();
            // services.AddScoped<StopLossTrailingRepository>();
            // services.AddScoped<StopLossTrendLineRepository>();
            // Services
            services.AddScoped<StockService>();
            services.AddScoped<StockWatchListService>();
            services.AddScoped<WatchListService>();
            // services.AddScoped<StopLossFixedService>();
            // services.AddScoped<StopLossRateOfReturnService>();
            // services.AddScoped<StopLossTrailingService>();
            // services.AddScoped<StopLossTrendLineService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseStaticFiles();

            app.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                     name: "default",
                     template: "{*path}",
                     defaults: new { controller = "Home", action = "Index" }
                );
            });


            // initialize sample data
            SampleData.Initialize(app.ApplicationServices).Wait();
            // System.Timers.Timer timer = new System.Timers.Timer(3000);

            /*
            TimerCallback tcb = new TimerCallback((e) =>
            {
                string text = "text";
                Console.WriteLine(text);
            });
            */

            autoEvent = new AutoResetEvent(false);

            // statusChecker = new StatusChecker(10);

            stockService = app.ApplicationServices.GetService<StockService>();

            // Create an inferred delegate that invokes methods for the timer.
            // TimerCallback tcb = statusChecker.CheckStatus;
            TimerCallback tcb = stockService.UpdateStocks;

            timer = new System.Threading.Timer(tcb, autoEvent, 30000, 10000);
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }


}
