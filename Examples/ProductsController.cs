using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> items = new List<string>();
            items.Add("Please select");
            items.Add("USA");
            items.Add("UK");
            items.Add("India");
            SelectList countries = new SelectList(items);
            ViewData["countries"] = countries;
            return View();
        }

        public JsonResult GetStates(string country)
        {
            List<string> states = new List<string>();
            switch (country)
            {
                case "USA":
                    states.Add("California");
                    states.Add("Florida");
                    states.Add("Ohio");
                    break;
                case "UK":
                    states.Add("England");
                    states.Add("Scotland");
                    break;
                case "India":
                    states.Add("Punjab");
                    break;
            }
            return Json(states);
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
    }
}