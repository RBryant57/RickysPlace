using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using Data.Core.Interfaces;

namespace Web.Core
{
    public class BaseController : Controller
    {
        protected IDataService service;
        protected IEntity entity;

        protected void getEntity(int id)
        {
            this.entity = this.service.FindById(id);
        }

        public virtual ActionResult Index(int? id)
        {
            ViewBag.Environment = ConfigurationManager.AppSettings.Get("Environment");
            return View(this.service.GetAll());
        }

        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (this.entity == null)
                this.getEntity((int)id);

            if (this.entity == null)
            {
                return HttpNotFound();
            }

            return View(this.entity);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            this.entity = this.service.FindById((int)id);
            if (this.entity == null)
            {
                return HttpNotFound();
            }

            return View(this.entity);
        }

        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            this.entity = this.service.FindById((int)id);
            if (this.entity == null)
            {
                return HttpNotFound();
            }

            return View(this.entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            this.entity = this.service.FindById((int)id);
            this.service.Delete(entity);
            return RedirectToAction("Index");
        }
    }
}