using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Demo.WebApi.Security.Web.Filters
{
    public class IPHostValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            var context = actionContext.Request.Properties["MS_HttpContext"] as System.Web.HttpContextBase;
            var userIP = context.Request.UserHostAddress;

            try
            {
                if (userIP != "127.0.0.1")
                    throw new Exception("Hey! I don't know this IP address!");
            }
            catch (Exception)
            {
                actionContext.Response =
                   new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                   {
                       Content = new StringContent("Unauthorized IP Address")
                   };
            }
        }
    }
}