using System;
using AspNetCoreApiKey.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreApiKey.Web.Filters
{
    public class AuthorizeApiKeyWithDIAttribute : ActionFilterAttribute
    {

        private IKeyStoreService _keyStoreService;

        public AuthorizeApiKeyWithDIAttribute(IKeyStoreService keyStoreService)
        {
            _keyStoreService = keyStoreService;
        }

        // Name of the api key header
        private const string ApiKeyName = "x-api-key";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var keyHeader = context.HttpContext.Request.Headers[ApiKeyName].ToString();
            if (string.IsNullOrEmpty(keyHeader))
            {
                context.Result = new ContentResult
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Content = "Access Key required"
                };
                return;
            }

            if (!_keyStoreService.IsValidKey(keyHeader))
            {
                context.Result = new ContentResult
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Content = "The provided key is either invalid or expired."
                };

                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
