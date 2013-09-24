using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace Demo.WebApi.Security.Web.Filters
{
    public class TokenValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string token;

            try
            {
                token = actionContext.Request.Headers.GetValues("Authorization-Token").First();
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Missing Authorization-Token")
                };
                return;
            }

            try
            {
                var goddToGo = RSAUtility.Decrypt(token) == "User1";
                if(!goddToGo) throw new Exception("Who are you? Not User1 that's for sure!");
                base.OnActionExecuting(actionContext);
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Unauthorized User")
                };
                return;
            }
        }
    }
}