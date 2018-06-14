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
using ShootingManager.Web.ViewModels;
using Web.Core;

namespace ShootingManager.Web.Controllers
{
    public class PrimerController : ShootingManagerBaseController
    {
        public PrimerController()
        {
            this.service = new PrimerService();
        }

        public PrimerController(IPrimerService iService)
        {
            this.service = iService;
        }

        public override ActionResult Index(int? id)
        {
            var entityViews = new List<PrimerViewModel>();

            using (var localService = this.service as IPrimerService)
            {
                foreach (PrimerView viewEntity in localService.GetPrimerViews().OrderBy(ev => ev.PrimerTypeName).ThenBy(ev => ev.PrimerFullName))
                {
                    var entityView = new PrimerViewModel();
                    var entity = new Primer { Id = viewEntity.Id, Name = viewEntity.Name, PrimerTypeId = viewEntity.PrimerTypeId, ManufacturerId = viewEntity.ManufacturerId, Notes = viewEntity.Notes };
                    entityView.Entity = entity;
                    entityView.EntityView = viewEntity;

                    entityViews.Add(entityView);
                }
            }

            return View(entityViews);
        }

        // GET: /Primer/Create
        public override ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name");
            ViewBag.PrimerTypeId = new SelectList(this.primerTypes, "Id", "Abbreviation");

            return base.Create();
        }

        // POST: /Primer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,PrimerTypeId,ManufacturerId,Notes")] Primer modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.ManufacturerId);
            ViewBag.PrimerTypeId = new SelectList(this.primerTypes, "Id", "Abbreviation", modEntity.PrimerTypeId);

            return View(modEntity);
        }

        public override ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entityViewModel = new PrimerViewModel();
            using (var localService = this.service as IPrimerService)
            {
                var entity = localService.GetAll().OfType<Primer>().Where(p => p.Id == id).First();

                var entityView = new PrimerView { ManufacturerName = entity.Manufacturer.Name, PrimerTypeName = entity.PrimerType.Name };

                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

        // GET: /Primer/Edit/5
        public override ActionResult Edit(int? id)
        {
            this.getEntity((int)id);
            using (var localEntity = this.entity as Primer)
            {
                ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", localEntity.ManufacturerId);
                ViewBag.PrimerTypeId = new SelectList(this.primerTypes, "Id", "Abbreviation", localEntity.PrimerTypeId);
            }

            return base.Edit(id);
        }

        // POST: /Primer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,PrimerTypeId,ManufacturerId,Notes")] Primer modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.ManufacturerId);
            ViewBag.PrimerTypeId = new SelectList(this.primerTypes, "Id", "Abbreviation", modEntity.PrimerTypeId);

            return View(modEntity);
        }

        public override ActionResult Delete(int? id)
        {
            var entityViewModel = new PrimerViewModel();
            using (var localService = this.service as IPrimerService)
            {
                var entity = localService.GetAll().OfType<Primer>().Where(p => p.Id == id).First();

                var entityView = new PrimerView { ManufacturerName = entity.Manufacturer.Name, PrimerTypeName = entity.PrimerType.Name };

                ViewBag.CanDelete = !(entity.Cartridges.Any() || entity.PrimerCosts.Any() || entity.PrimerQuantities.Any());
                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

    }
}
