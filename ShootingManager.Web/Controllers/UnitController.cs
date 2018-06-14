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
    public class UnitController : ShootingManagerBaseController
    {
        public UnitController()
        {
            this.service = new UnitService();
        }

        public UnitController(IUnitService iService)
        {
            this.service = iService;
        }

        public override ActionResult Index(int? id)
        {
            var entityViews = new List<UnitViewModel>();

            using (var localService = this.service as IUnitService)
            {
                foreach (UnitView viewEntity in localService.GetUnitViews().OrderBy(e => e.Name))
                {
                    var entityView = new UnitViewModel();
                    var entity = new Unit { Id = viewEntity.Id, Name = viewEntity.Name, Plural = viewEntity.Plural, Abbreviation = viewEntity.Abbreviation, UnitTypeId = viewEntity.UnitTypeId, Notes = viewEntity.Notes };
                    entityView.Entity = entity;
                    entityView.EntityView = viewEntity;

                    entityViews.Add(entityView);
                }
            }

            return View(entityViews);
        }

        // GET: /Unit/Create
        public override ActionResult Create()
        {
            ViewBag.UnitTypeId = new SelectList(((UnitService)this.service).GetUnitTypes(), "Id", "Name");
            return base.Create();
        }

        // POST: /Unit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Plural,Abbreviation,UnitTypeId,Notes")] Unit modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.UnitTypeId = new SelectList(this.unitTypes, "Id", "Name", modEntity.UnitTypeId);
            return View(modEntity);
        }

        // GET: /Unit/Edit/5
        public override ActionResult Edit(int? id)
        {
            this.getEntity((int)id);
            ViewBag.UnitTypeId = new SelectList(this.unitTypes, "Id", "Name", ((Unit)this.entity).UnitTypeId);

            return base.Edit(id);
        }

        // POST: /Unit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Plural,Abbreviation,UnitTypeId,Notes")] Unit modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.UnitTypeId = new SelectList(this.unitTypes, "Id", "Name", modEntity.UnitTypeId);

            return View(modEntity);
        }

        public override ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entityViewModel = new UnitViewModel();
            using (var localService = this.service as IUnitService)
            {
                var entity = localService.GetAll().OfType<Unit>().Where(b => b.Id == id).First();

                var entityView = new UnitView { UnitTypeName = entity.UnitType.Name };

                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

        public override ActionResult Delete(int? id)
        {
            var entityViewModel = new UnitViewModel();
            using (var localService = this.service as IUnitService)
            {
                var entity = localService.GetAll().OfType<Unit>().Where(b => b.Id == id).First();

                var entityView = new UnitView { UnitTypeName = entity.UnitType.Name };

                ViewBag.CanDelete = !(entity.Brasses.Any() || entity.Calibers.Any() || entity.COLUnitCartridgeLoads.Any() || entity.DiameterUnitBullets.Any() || entity.PowderQuantities.Any() || entity.PrimerQuantities.Any());
                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

    }
}
