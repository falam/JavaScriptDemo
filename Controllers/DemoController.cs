using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JavaScriptDemo.Models;

namespace JavaScriptDemo.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/

        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public ActionResult FormDemo()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { Date = DateTime.Now.ToString() });
            }
            string name = HttpContext.Request.Form["name"];

            if (!string.IsNullOrEmpty(name))
            {
                ViewBag.Message = name;
                return View();
            }
            if (!HttpContext.Request.HttpMethod.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
                ViewBag.Message = "Your name?";

            return View();
        }
        /*
        [HttpPost]
        public ActionResult FormDemo()
        {
            return View();
        }*/
    }
}
