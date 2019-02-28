using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApiKey.Web.Services
{
    public class DbKeyStoreService : IKeyStoreService
    {
        public bool IsValidKey(string key)
        {
            // You can build here a mechanism to store and manage keys and valid that using this service
            throw new NotImplementedException();
        }
    }
}
