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

namespace QuickStart2_WebApiClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }



    public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()

            //WebHost.CreateDefaultBuilder(args)
            //.ConfigureAppConfiguration((hostingBuilderContext, configBuilder) =>
            //        {
            //            configBuilder.AddApollo(configBuilder.Build().GetSection("apollo")).AddDefault();
            //        }
            //    )
            //.UseStartup<Startup>()
            .Build();
    }
}
