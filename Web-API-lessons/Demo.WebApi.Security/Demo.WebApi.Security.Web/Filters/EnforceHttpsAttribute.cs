using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Demo.WebApi.Security.Web.Filters
{
    public class EnforceHttpsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!String.Equals(actionContext.Request.RequestUri.Scheme, "https", StringComparison.OrdinalIgnoreCase))
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("HTTPS Required")
                };
                return;
            }
        }
    }
}
