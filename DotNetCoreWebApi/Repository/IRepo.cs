using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApi.Repository
{
    public interface IRepo
    {
        Task<string> GetItem(string key);

        Task<bool> SetItem(string key, string value);
    }
}
