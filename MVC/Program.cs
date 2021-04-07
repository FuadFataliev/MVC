using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build();

            Models.Company company = (Models.Company)host.Services.GetService(typeof(Services.ICompany));

            try
            {
                company.FillStaff();
            }
            catch (Exception ex)
            {
                var logger = (ILogger<Program>)host.Services.GetService(typeof(ILogger<Program>));

                logger.LogError(ex, "An error occurred while filling company's staff!");
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
