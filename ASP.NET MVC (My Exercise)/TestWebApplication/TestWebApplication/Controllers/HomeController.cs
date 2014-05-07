using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Trace.TraceInformation(RouteData.Values["controller"].ToString());
            //Trace.TraceInformation(RouteData.Values["action"].ToString());
            //Debug.WriteLine(this.Request.UserAgent);

            //return this.Redirect("https://google.com");
            //return this.RedirectToAction("About");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ReturnJson()
        {
            return this.Json(DateTime.Now, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReturnJS()
        {
            return this.JavaScript("var a = 1; alert(a);");
        }

        public ActionResult ReturnFile()
        {
            return new HttpUnauthorizedResult();
            return this.File(@"C:\test.txt", "application\txt", "test.txt");
        }
    }
}