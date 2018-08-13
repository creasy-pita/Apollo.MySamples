using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace QuickStart4_WebApiClienWithApollo.Configuration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration( (hostBuilderContext, builder) => {
                    builder.AddJsonFile("appsettings.Development.json")
                    .AddApollo(builder.Build().GetSection("apollo"))
                    .AddDefault()
                    .AddNamespace("application");
                })

                .UseStartup<Startup>()
                .Build();
    }
}
