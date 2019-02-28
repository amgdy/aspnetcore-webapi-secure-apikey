using AspNetCoreApiKey.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApiKey.Web.Filters
{
    public class AuthorizeApiKeyAttribute : TypeFilterAttribute
    {
        //Here we are not using DI, we are injecting here InMemoryKeyStoreService
        public AuthorizeApiKeyAttribute() : base(typeof(AuthorizeApiKeyWithDIAttribute))
        {

        }
    }
}
