﻿using System;
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
    public class PowderShapeController : BaseController
    {
        public PowderShapeController()
        {
            this.service = new PowderShapeService();
        }

        public PowderShapeController(IPowderShapeService iService)
        {
            this.service = iService;
        }

        public override ActionResult Index(int? id)
        {
            using (var localService = this.service as PowderShapeService)
            {
                return View(localService.GetAll().OfType<PowderShape>().OrderBy(e => e.Name));
            }
        }

        // POST: /PowderShape/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Notes")] PowderShape modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                
                return RedirectToAction("Index");
            }

            return View(modEntity);
        }

        // POST: /PowderShape/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Notes")] PowderShape modEntity)
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

            ViewBag.CanDelete = !((this.entity as PowderShape).Powders.Any());
            return View(this.entity);
        }

    }
}
