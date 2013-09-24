using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Demo.WebApi.Security.Web.Filters
{
    public class EnforceHttpsForWebAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Url.Scheme.Equals("https")) return;

            throw new HttpException((int)HttpStatusCode.BadRequest, "HTTPS Required");
        }
    }
}