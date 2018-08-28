using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuickStart4_WebApiClienWithApollo.Configuration.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ApolloConfigManager _apolloConfigManager;

        public ValuesController(ApolloConfigManager apolloConfigManager)
        {
            _apolloConfigManager = apolloConfigManager;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string value =_apolloConfigManager.GetConfig("ID");
            //string value =_apolloConfigManager.GetConfig("config.jdbc.username");
            return new string[] { "value1", "value2",  value};
        }

    }
}
