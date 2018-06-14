using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShootingManager.Entities.Models;
using System.Configuration;

using ShootingManager.Service;
using ShootingManager.Service.Interfaces;
using Web.Core;

namespace ShootingManager.Web.Controllers
{
    public class BulletTypeController : BaseController
    {
        public BulletTypeController()
        {
            this.service = new BulletTypeService();
        }

        public BulletTypeController(IBulletTypeService iBulletTypeService)
        {
            this.service = iBulletTypeService;
        }

        public override ActionResult Index(int? id)
        {
            using(var localService = this.service as BulletTypeService)
            {
                return View(localService.GetAll().OfType<BulletType>().OrderBy(e => e.Abbreviation));
            }
        }

        // POST: /BulletType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Abbreviation,Notes")] BulletType modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                return RedirectToAction("Index");
            }

            return View(modEntity);
        }

        // POST: /BulletType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Abbreviation,Notes")] BulletType modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(modEntity);
                return RedirectToAction("Index");
            }

            return View(modEntity);
        }

        public override ActionResult Delete(int? id)
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

            ViewBag.CanDelete = !((this.entity as BulletType).Bullets.Any());
            return View(this.entity);
        }

    }
}
