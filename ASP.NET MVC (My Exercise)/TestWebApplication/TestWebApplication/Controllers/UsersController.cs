using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWebApplication.Controllers
{
    public class Params
    {
        public int IntValue { get; set; }

        //[Required]
        public string StringValue {get; set;}
    }
    public class UsersController : Controller
    {
        //public ActionResult ByUsername(string username)
        //{
        //    if (string.IsNullOrWhiteSpace(username))
        //    {
        //        return this.Content("No username entered");
        //    }
        //    return this.Content(string.Format("Username is: {0}", username));
        //}

        public ActionResult ByUsername(Params @params)
        {
            Debug.WriteLine(ModelState.IsValid);
            return Json(@params, JsonRequestBehavior.AllowGet);
        }
    }
}