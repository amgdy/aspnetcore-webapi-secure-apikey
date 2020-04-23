using System;
using System.Collections.Generic;

namespace AspNetCoreApiKey.Web.Services
{
    /// <summary>
    /// Dictionary based Key Store Service
    /// </summary>
    public class InMemoryKeyStoreService : IKeyStoreService
    {
        private static Dictionary<string, DateTime> _keyStore = new Dictionary<string, DateTime>
        {
            { "a689a999a5e62055bda8c21b1dbe92c119308def", new DateTime(2019,1,1) },
            { "0dca48f101f6458f456df25e62cc89d83b7c467c", new DateTime(2020,6,1) },
            { "f58ab51695b501095418ac9718da10d0c70d4b59", new DateTime(2025,1,1) },
        };

        public bool IsValidKey(string key)
        {
            return _keyStore.TryGetValue(key, out DateTime expiryDate) && expiryDate > DateTime.Now;
        }
    }
}
