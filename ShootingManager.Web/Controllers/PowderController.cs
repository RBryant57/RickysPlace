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
    public class PowderController : ShootingManagerBaseController
    {
        public PowderController()
        {
            this.service = new PowderService();
        }

        public PowderController(IPowderService iPowderService)
        {
            this.service = iPowderService;
        }

        public override ActionResult Index(int? id)
        {
            var entityViewModels = new List<PowderViewModel>();
            IEnumerable<Powder> entityViews;

            using (var localService = this.service as IPowderService)
            {
                entityViews = localService.GetAll().OfType<Powder>().ToList();

                foreach (Powder entity in entityViews.OrderBy(ev => ev.PowderType.Name).ThenBy(ev => ev.Name))
                {
                    var entityViewModel = new PowderViewModel();
                    var entityView = new PowderView { ManufacturerName = entity.Manufacturer.Name, PowderShapeName = entity.PowderShape.Name, PowderTypeName = entity.PowderType.Name };

                    entityViewModel.Entity = entity;
                    entityViewModel.EntityView = entityView;
                    entityViewModels.Add(entityViewModel);
                }
            }

            return View(entityViewModels);
        }

        // GET: /Powder/Create
        public override ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name");
            ViewBag.PowderShapeId = new SelectList(this.powderShapes, "Id", "Name");
            ViewBag.PowderTypeId = new SelectList(this.powderTypes, "Id", "Name");

            return base.Create();
        }

        // POST: /Powder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,ManufacturerId,PowderTypeId,PowderShapeId,Notes")] Powder modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.MaufacturerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.ManufacturerId);
            ViewBag.PowderShapeId = new SelectList(this.powderShapes, "Id", "Name", modEntity.PowderShapeId);
            ViewBag.PowderTypeId = new SelectList(this.powderTypes, "Id", "Name", modEntity.PowderTypeId);

            return View(modEntity);
        }

        // GET: /Powder/Edit/5
        public override ActionResult Edit(int? id)
        {
            this.getEntity((int)id);

            using (var localEntity = this.entity as Powder)
            {
                ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", localEntity.ManufacturerId);
                ViewBag.PowderShapeId = new SelectList(this.powderShapes, "Id", "Name", localEntity.PowderShapeId);
                ViewBag.PowderTypeId = new SelectList(this.powderTypes, "Id", "Name", localEntity.PowderTypeId);
            }

            return base.Edit(id);
        }

        // POST: /Powder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,ManufacturerId,PowderTypeId,PowderShapeId,Notes")] Powder modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.ManufacturerId);
            ViewBag.PowderShapeId = new SelectList(this.powderShapes, "Id", "Name", modEntity.PowderShapeId);
            ViewBag.PowderTypeId = new SelectList(this.powderTypes, "Id", "Name", modEntity.PowderTypeId);

            return View(modEntity);
        }

        public override ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entityViewModel = new PowderViewModel();
            using (var localService = this.service as IPowderService)
            {
                var entity = localService.GetAll().OfType<Powder>().Where(b => b.Id == id).First();

                var entityView = new PowderView { ManufacturerName = entity.Manufacturer.Name, PowderShapeName = entity.PowderShape.Name, PowderTypeName = entity.PowderType.Name };

                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

        public override ActionResult Delete(int? id)
        {
            var entityViewModel = new PowderViewModel();
            using (var localService = this.service as IPowderService)
            {
                var entity = localService.GetAll().OfType<Powder>().Where(b => b.Id == id).First() as Powder;

                var entityView = new PowderView { ManufacturerName = entity.Manufacturer.Name, PowderShapeName = entity.PowderShape.Name, PowderTypeName = entity.PowderType.Name };

                entityViewModel.CanDelete = !(entity.CartridgeLoads.Any() || entity.PowderCosts.Any() || entity.PowderQuantities.Any());
                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

        public JsonResult DeletePowder(int id)
        {
            using (var localService = this.service as PowderService)
            {
                var entities = localService.GetCartridgeLoads().Where(e => e.PowderId == id);
                if (entities.Count() == 0)
                    return Json(true);

                return Json(false);
            }
        }

    }
}
