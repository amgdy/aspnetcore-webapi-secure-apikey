using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApiKey.Web.Services
{
    /// <summary>
    /// Dictionary based Key Store Service
    /// </summary>
    public class InMemoryKeyStoreService : IKeyStoreService
    {
        private static Dictionary<string, DateTime> _keyStore = new Dictionary<string, DateTime>
        {
            { "1", new DateTime(2019,1,1) },
            { "2", new DateTime(2020,1,1) },
            { "3", new DateTime(2021,1,1) },
        };
        public bool IsValidKey(string key)
        {
            DateTime expiryDate;
            return _keyStore.TryGetValue(key, out expiryDate) && expiryDate > DateTime.Now;
        }
    }
}
