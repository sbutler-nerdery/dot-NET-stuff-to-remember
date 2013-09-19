using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Demo.AngularJs.MvcWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetMovies()
        {
            var url =
                "http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apiKey=vbp26ua7wx3yzd4429nz7e5a";
            var response = new DemoResponse { Success = false, Data = "An unknown error ocurred."};

            try
            {
                using (var client = new WebClient())
                {
                    var bytes = await Task.Run(() => client.DownloadData(new Uri(url)));
                    response.Data = Encoding.ASCII.GetString(bytes);
                }
            }
            catch (Exception ex)
            {
                response.Data = ex.GetBaseException().Message;
                response.Success = false;
            }

            return Json(response);
        }

        class DemoResponse
        {
            public bool Success { get; set; }
            public string Data { get; set; }
        }
    }
}
