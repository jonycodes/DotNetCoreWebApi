using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApi.Config
{
    public class WebApiConfig
    {
        public string RedisUrl { get; set; }

        public int RedisPort { get; set; }
    }
}
