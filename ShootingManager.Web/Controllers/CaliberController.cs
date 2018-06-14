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
    public class CaliberController : ShootingManagerBaseController
    {
        public CaliberController()
        {
            this.service = new CaliberService();
        }

        public CaliberController(ICaliberService iCaliberService)
        {
            this.service = iCaliberService;
        }
        public override ActionResult Index(int? id)
        {
            ViewBag.Environment = ConfigurationManager.AppSettings.Get("Environment");

            var entityViewModels = new List<CaliberViewModel>();
            IEnumerable<Caliber> entityViews;

            using (var localService = this.service as ICaliberService)
            {
                if (id != null)
                {
                    entityViews = from entityView in localService.GetAll().OfType<Caliber>()
                                  where entityView.Id == id
                                  select entityView;
                    ViewBag.CaliberName = entityViews.First().Name;
                }
                else
                {
                    var x = localService.GetAll();
                    entityViews = localService.GetAll().OfType<Caliber>().ToList();
                    ViewBag.CaliberName = "All Calibers";
                }

                foreach (Caliber entity in entityViews.OrderBy(ev => ev.SortOrder))
                {
                    var entityViewModel = new CaliberViewModel();
                    var entityView = new CaliberView { PrimerTypeAbbreviation = entity.PrimerType.Abbreviation, DiameterUnitViewAbbreviation = entity.DiameterUnit.Abbreviation, BrassLengthUnitViewAbbreviation = entity.BrassLengthUnit.Abbreviation };

                    entityViewModel.Entity = entity;
                    entityViewModel.EntityView = entityView;
                    entityViewModels.Add(entityViewModel);
                }
            }

            return View(entityViewModels);

        }

        // GET: /Caliber/Create
        public override ActionResult Create()
        {
            ViewBag.DiameterUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation");
            ViewBag.BrassLengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation");
            ViewBag.PrimerTypeId = new SelectList(this.primerTypes, "Id", "Abbreviation");

            return base.Create();
        }

        // POST: /Caliber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Diameter,DiameterUnitId,BrassLength,BrassLengthUnitId,SortOrder,PrimerTypeId,Notes")] Caliber modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);

                var maxSortCaliber = this.service.GetAll().OfType<Caliber>().OrderBy(c => c.SortOrder).Last();
                if (modEntity.SortOrder < maxSortCaliber.SortOrder)
                    this.updateSortOrder(modEntity.Id, modEntity.SortOrder, 1);

                return RedirectToAction("Index");
            }

            ViewBag.DiameterUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", modEntity.DiameterUnitId);
            ViewBag.BrassLengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", modEntity.BrassLengthUnitId);
            ViewBag.PrimerTypeId = new SelectList(this.primerTypes, "Id", "Abbreviation", modEntity.PrimerTypeId);

            return View(modEntity);
        }

        // GET: /Caliber/Edit/5
        public override ActionResult Edit(int? id)
        {
            this.getEntity((int)id);

            using (var localEntity = this.entity as Caliber)
            {
                ViewBag.DiameterUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", localEntity.DiameterUnitId);
                ViewBag.BrassLengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", localEntity.BrassLengthUnitId);
                ViewBag.PrimerTypeId = new SelectList(this.primerTypes, "Id", "Abbreviation", localEntity.PrimerTypeId);
            }

            return base.Edit(id);
        }

        // POST: /Caliber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Diameter,DiameterUnitId,BrassLength,BrassLengthUnitId,SortOrder,PrimerTypeId,Notes")] Caliber modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(modEntity);

                //var maxSortCaliber = this.service.GetAll().OfType<Caliber>().OrderBy(c => c.SortOrder).Last();
                //if (modEntity.SortOrder < maxSortCaliber.SortOrder)
                //    this.updateSortOrder(modEntity.Id, modEntity.SortOrder);

                return RedirectToAction("Index");
            }

            ViewBag.DiameterUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", modEntity.DiameterUnitId);
            ViewBag.BrassLengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", modEntity.BrassLengthUnitId);
            ViewBag.PrimerTypeId = new SelectList(this.primerTypes, "Id", "Abbreviation", modEntity.PrimerTypeId);

            return View(modEntity);
        }

        public override ActionResult Delete(int? id)
        {
            var entityViewModel = new CaliberViewModel();
            using (var localService = this.service as ICaliberService)
            {
                var entity = localService.GetAll().OfType<Caliber>().Where(b => b.Id == id).First();
                var entityView = new CaliberView { PrimerTypeAbbreviation = entity.PrimerType.Abbreviation, DiameterUnitViewAbbreviation = entity.DiameterUnit.Abbreviation, BrassLengthUnitViewAbbreviation = entity.BrassLengthUnit.Abbreviation };

                entityViewModel.CanDelete = !(entity.Brasses.Any() || entity.CartridgeLoads.Any() || entity.Guns.Any());
                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override ActionResult DeleteConfirmed(int id)
        {
            this.entity = this.service.FindById((int)id);
            this.service.Delete(this.entity);

            using (var localEntity = this.entity as Caliber)
            {
                var maxSortCaliber = this.service.GetAll().OfType<Caliber>().OrderBy(c => c.SortOrder).Last();
                if (localEntity.SortOrder < maxSortCaliber.SortOrder)
                    this.updateSortOrder(localEntity.Id, localEntity.SortOrder, -1);
            }

            return RedirectToAction("Index");
        }

        public override ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entityViewModel = new CaliberViewModel();
            using (var localService = this.service as ICaliberService)
            {
                var entity = localService.GetAll().OfType<Caliber>().Where(c => c.Id == id).First();
                var entityView = new CaliberView { PrimerTypeAbbreviation = entity.PrimerType.Abbreviation, DiameterUnitViewAbbreviation = entity.DiameterUnit.Abbreviation, BrassLengthUnitViewAbbreviation = entity.BrassLengthUnit.Abbreviation };

                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

        private void updateSortOrder(int calId, int modSortOrder, int direction)
        {
            var calibers = (from caliber in this.service.GetAll().OfType<Caliber>()
                            where caliber.SortOrder >= modSortOrder && caliber.Id != calId
                            select caliber).OrderBy(c => c.SortOrder).ToList();


            foreach(var caliber in calibers)
            {
                caliber.SortOrder = caliber.SortOrder += direction;
                ((CaliberService)this.service).Edit(caliber);
            }

        }

    }
}
