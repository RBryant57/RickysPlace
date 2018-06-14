using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShootingManager.Entities.Models;
using System.Reflection;
using System.IO;
using System.Xml.Linq;

using ShootingManager.Service;
using ShootingManager.Service.Interfaces;
using ShootingManager.Web.Common;
using Web.Core;

namespace ShootingManager.Web.Controllers
{
    public class ManufacturerController : BaseController
    {
        public ManufacturerController()
        {
            this.service = new ManufacturerService();
        }

        public ManufacturerController(IManufacturerService iManufacturerService)
        {
            this.service = iManufacturerService;
        }

        public override ActionResult Index(int? id)
        {
            using (var localService = this.service as ManufacturerService)
            {
                return View(localService.GetAll().OfType<Manufacturer>().OrderBy(e => e.Name));
            }
        }

        // GET: /Manufacturer/Create
        public override ActionResult Create()
        {
            ViewBag.State = new SelectList(State.GetStates(), "Abbreviation", "Abbreviation");
            return base.Create();
        }

        // POST: /Manufacturer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,ShortName,Address,City,State,Zip,URL,Notes")] Manufacturer modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.State = new SelectList(State.GetStates(), "Abbreviation", "Abbreviation");
            return View(modEntity);
        }

        // GET: /Manufacturer/Edit/5
        public override ActionResult Edit(int? id)
        {
            this.getEntity((int)id);
            ViewBag.State = new SelectList(State.GetStates(), "Abbreviation", "Abbreviation", ((Manufacturer)this.entity).State);

            return base.Edit(id);
        }

        // POST: /Manufacturer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,ShortName,Address,City,State,Zip,URL,Notes")] Manufacturer modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.State = new SelectList(State.GetStates(), "Abbreviation", "Abbreviation", modEntity.State);
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

            var localEntity = this.entity as Manufacturer;
            ViewBag.CanDelete = !(localEntity.Brasses.Any() || localEntity.Bullets.Any() || localEntity.Cartridges.Any() || localEntity.GunsManufacturers.Any() || localEntity.Powders.Any() || localEntity.Primers.Any());
            return View(this.entity);
        }

    }
}
