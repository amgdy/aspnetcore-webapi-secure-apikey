using AspNetCoreApiKey.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreApiKey.Web.Filters
{
    public sealed class AuthorizeForApiKeyAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// The HTTP Header Name to be used in the request. The default is <code>x-api-key</code>
        /// </summary>
        public string HeaderName { get; set; } = "x-api-key";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var keyHeader = context.HttpContext.Request.Headers[HeaderName].ToString();
            if (string.IsNullOrEmpty(keyHeader))
            {
                context.Result = new ContentResult
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Content = "Access Key required"
                };

                return;
            }

            // Here should be your code to validate the key itself.
            // I used the IoC feature in ASP.NET Core to get the available Key Store
            var keystoreService = context.HttpContext.RequestServices.GetService<IKeyStoreService>();

            if (!keystoreService.IsValidKey(keyHeader))
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
