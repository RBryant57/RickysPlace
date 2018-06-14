using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShootingManager.Web.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/
        public ActionResult Index()
        {
            ViewBag.Environment = ConfigurationManager.AppSettings.Get("Environment");
            return View();
        }
	}
}