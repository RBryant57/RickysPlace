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
using ShootingManager.Web.Common;
using Web.Core;

namespace ShootingManager.Web.Controllers
{
    public class ShootingLocationController : ShootingManagerBaseController
    {
        public ShootingLocationController()
        {
            this.service = new ShootingLocationService();
        }

        public ShootingLocationController(IShootingLocationService iService)
        {
            this.service = iService;
        }

        public override ActionResult Index(int? id)
        {
            using (var localService = this.service as ShootingLocationService)
            {
                return View(localService.GetAll().OfType<ShootingLocation>().OrderBy(e => e.State).ThenBy(e => e.Name));
            }
        }

        // GET: /ShootingLocation/Create
        public override ActionResult Create()
        {
            ViewBag.State = new SelectList(State.GetStates(), "Abbreviation", "Abbreviation");
            return base.Create();
        }

        // POST: /ShootingLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,State,Location,Notes")] ShootingLocation modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.State = new SelectList(State.GetStates(), "Abbreviation", "Abbreviation");
            return View(modEntity);
        }

        // GET: /ShootingLocation/Edit/5
        public override ActionResult Edit(int? id)
        {
            this.getEntity((int)id);
            ViewBag.State = new SelectList(State.GetStates(), "Abbreviation", "Abbreviation", ((ShootingLocation)this.entity).State);
            return base.Edit(id);
        }

        // POST: /ShootingLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,State,Location,Notes")] ShootingLocation modEntity)
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

            var entity = this.service.FindById((int)id) as ShootingLocation;
            if (entity == null)
            {
                return HttpNotFound();
            }

            ViewBag.CanDelete = !entity.ShootingSessions.Any();
            return View(entity);
        }

    }
}
