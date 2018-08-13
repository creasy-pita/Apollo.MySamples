using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace QuickStart2_WebApiClient.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IConfiguration _configuration;
        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            ApolloConfigManager m = new ApolloConfigManager();
            string port = m.GetConfig("config.jdbc.username");
            //string s = _configuration["server.port"];
            //string mailtos = _configuration.GetValue<string>("server.port");
            return new string[] { "value1", "value2", port };
        }

    }
}
