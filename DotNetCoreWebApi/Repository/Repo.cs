using DotNetCoreWebApi.Config;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApi.Repository
{
    public class Repo : IRepo
    {
        private readonly WebApiConfig config;

        private readonly IDistributedCache cacheInstance;

        public Repo(
            IOptionsMonitor<WebApiConfig> optionsAccessor,
            IDistributedCache cacheInstance)
        {
            this.cacheInstance = cacheInstance;
            this.config = optionsAccessor.CurrentValue;
        }

        public Task<string> GetItem(string key)
        {
            return cacheInstance.GetStringAsync(key);
        }


        public async Task<bool> SetItem(string key, string value)
        {
            try
            {
                await cacheInstance.SetStringAsync(key, value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
