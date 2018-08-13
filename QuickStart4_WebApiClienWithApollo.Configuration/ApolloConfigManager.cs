using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuickStart4_WebApiClienWithApollo.Configuration.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickStart4_WebApiClienWithApollo
{
    public class ApolloConfigManager
    {
        //private static readonly IConfiguration Configuration;
        static ApolloConfigManager()
        {
            //var builder = new ConfigurationBuilder();

            //builder.AddJsonFile("appsettings.Development.json");
            //builder
            //.AddApollo(builder.Build().GetSection("apollo"))
            //.AddDefault()
            //.AddNamespace("application");

            //Configuration = builder.Build();
        }

        private readonly string DEFAULT_VALUE = "undefined";
        private readonly IConfiguration config;
        private readonly IConfiguration anotherConfig;

        public ApolloConfigManager(IServiceCollection services, IConfiguration Configuration)
        {
            config = Configuration;
            anotherConfig = Configuration.GetSection("TEST1.test");
            services.AddSingleton<ApolloConfigurationManager>();

            //services.AddOptions()
            ////.Configure<Value>(config)
            ////.Configure<Value>("other", anotherConfig);

            ////.Configure<ApplicationSetting>(config);
            // .Configure<apollo>(config.GetSection("apollo"));

            var serviceProvider = services.BuildServiceProvider();

            //var optionsMonitor = serviceProvider.GetService<IOptionsMonitor<Value>>();
            //// var optionsMonitor = serviceProvider.GetService<IOptionsMonitor<ApplicationSetting>>();
             //var optionsMonitor = serviceProvider.GetService<IOptionsMonitor<apollo>>();
             //optionsMonitor.OnChange(OnChanged);

            new ConfigurationManagerDemo(serviceProvider.GetService<ApolloConfigurationManager>());
        }

        public string GetConfig(string key)
        {
            var result = config.GetValue(key, DEFAULT_VALUE);
            if (result.Equals(DEFAULT_VALUE))
            {
                result = anotherConfig.GetValue(key, DEFAULT_VALUE);
            }
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Loading key: {0} with value: {1}", key, result);
            Console.ForegroundColor = color;

            return result;
        }

        private void OnChanged(apollo value)
        {
            Console.WriteLine( " has changed: " + JsonConvert.SerializeObject(value));
        }

        private void OnChanged(Value value)
        {
            Console.WriteLine(" has changed: " + JsonConvert.SerializeObject(value));
        }

        //private void OnChanged(ConfigurationRoot value, string name)
        //{
        //    Console.WriteLine(name + " has changed: " + JsonConvert.SerializeObject(value));
        //}

        //private void OnChanged(ApplicationSetting value, string name)
        //{
        //    Console.WriteLine(name + " has changed: " + JsonConvert.SerializeObject(value));
        //}
        private class Value
        {
            public string Timeout { get; set; }
        }
    }
}
