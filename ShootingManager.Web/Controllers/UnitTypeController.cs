using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using ShootingManager.Entities.Models;
using ShootingManager.Service;
using ShootingManager.Service.Interfaces;
using Web.Core;

namespace ShootingManager.Web.Controllers
{
    public class UnitTypeController : BaseController
    {
        public UnitTypeController()
        {
            this.service = new UnitTypeService();
        }

        public UnitTypeController(IUnitTypeService iService)
        {
            this.service = iService;
        }

        public override ActionResult Index(int? id)
        {
            using (var localService = this.service as UnitTypeService)
            {
                return View(localService.GetAll().OfType<UnitType>().OrderBy(e => e.Name));
            }
        }

        // POST: /UnitType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Notes")] UnitType modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                return RedirectToAction("Index");
            }

            return View(modEntity);
        }

        // POST: /UnitType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Notes")] UnitType modEntity)
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

            var entity = this.service.FindById((int)id) as UnitType;
            if (entity == null)
            {
                return HttpNotFound();
            }

            ViewBag.CanDelete = !entity.Units.Any();
            return View(entity);
        }

    }
}
