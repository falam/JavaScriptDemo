using System;
using System.Web.Mvc;

namespace TemperatureCalculator.Controllers
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

        public ActionResult TemperatureConvert()
        {
            if (Request.IsAjaxRequest())
            {
                string tempInC = HttpContext.Request.Form["tempInC"];
                double input, result;

                if (Double.TryParse(tempInC, out input))
                {
                    result = ((input * 9) / 5) + 32;
                    return Json(new {Result = result});
                }
            }

            //if (!string.IsNullOrEmpty(name))
            //{
            //    ViewBag.Message = name;
            //    return View("FormDemo");
            //}
            //if (!HttpContext.Request.HttpMethod.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
            //    ViewBag.Message = "Your name?";

            return View("FormDemo");
        }

        /*
        [HttpPost]
        public ActionResult FormDemo()
        {
            return View();
        }*/
    }
}
