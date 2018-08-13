using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QuickStart4_WebApiClienWithApollo.Configuration.data;

namespace QuickStart4_WebApiClienWithApollo.Configuration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddOptions().Configure<TempUser>(Configuration.GetSection("TestUser"));

            //var serviceProvider = services.BuildServiceProvider();
            //var optionsMonitor = serviceProvider.GetService<IOptionsMonitor<TempUser>>();
            //optionsMonitor.OnChange(OnChanged);

            services.AddOptions()
            .Configure<apollo>(Configuration.GetSection("apollo"));

            var serviceProvider = services.BuildServiceProvider();

            // var optionsMonitor = serviceProvider.GetService<IOptionsMonitor<ApplicationSetting>>();
            var optionsMonitor = serviceProvider.GetService<IOptionsMonitor<apollo>>();
            optionsMonitor.OnChange(OnChanged);

            ApolloConfigManager apolloConfigManager = new ApolloConfigManager(services,Configuration);
            services.AddSingleton(typeof(ApolloConfigManager), apolloConfigManager);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
        }
        public void OnChanged(apollo user)
        {
            Console.WriteLine("apollo  changed");
        }
        public void OnChanged(TempUser user)
        {
            Console.WriteLine("TempUser  changed");
        }
    }
}
