using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using local.yellowcaddis.ShootingManager.Core.Abstract;
using local.yellowcaddis.ShootingManager.Core.Entities;

namespace local.yellowcaddis.ShootingManager.Web.Controllers
{
    public class NavController : Controller
    {
        private ICaliberRepository repository;

        public NavController(ICaliberRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(Caliber caliber = null)
        {
            ViewBag.SelectedCaliber = caliber;

            IEnumerable<string> categories = repository.Calibers
                                    .Select(x => x.Name)
                                    .Distinct()
                                    .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}
