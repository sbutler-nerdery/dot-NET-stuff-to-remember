using System.Web;
using System.Web.Mvc;
using Demo.WebApi.Security.Web.Filters;

namespace Demo.WebApi.Security.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new EnforceHttpsForWebAttribute());
        }
    }
}