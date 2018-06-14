using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using ShootingManager.Entities.Models;
using ShootingManager.Service;
using ShootingManager.Service.Interfaces;
using ShootingManager.Web.Common;
using ShootingManager.Web.ViewModels;
using Web.Core;

namespace ShootingManager.Web.Controllers
{
    public class BrassController : ShootingManagerBaseController
    {
        public BrassController()
        {
            this.service = new BrassService();
        }

        public BrassController(IBrassService service) : base(service)
        {
            this.service = service;
        }

        public override ActionResult Index(int? id)
        {
            var entityViewModels = new List<BrassViewModel>();
            IEnumerable<Brass> entityViews;

            using (var localService = this.service as IBrassService)
            {
                if (id != null)
                {
                    entityViews = from brassView in localService.GetAll().OfType<Brass>().ToList()
                              where brassView.CaliberId == id
                              select brassView;
                    ViewBag.CaliberName = entityViews.First().Caliber.Name;
                }
                else
                {
                    entityViews = localService.GetAll().OfType<Brass>();
                    ViewBag.CaliberName = "All Calibers";
                }

                foreach(Brass entity in entityViews.OrderBy(ev => ev.Caliber.SortOrder).ThenBy(ev => ev.Name))
                {
                    var brassViewModel = new BrassViewModel();
                    var entityView = new BrassView { ManufacturerName = entity.Manufacturer.Name, MaterialName = entity.Material.Name, CaliberViewName = entity.Caliber.Name, CaliberViewBrassLengthUnitViewAbbreviation = entity.Caliber.BrassLengthUnit.Abbreviation, CaliberViewBrassLength = entity.Caliber.BrassLength };

                    brassViewModel.Entity = entity;
                    brassViewModel.EntityView = entityView;
                    entityViewModels.Add(brassViewModel);
                }
            }

            ViewBag.BrassId = new SelectList(this.brassViews.OrderBy(b => b.CaliberViewSortOrder).ThenBy(b => b.BrassName), "Id", "BrassName");
            return View(entityViewModels);

        }

        // GET: /Brass/Create
        public override ActionResult Create()
        {
            var calibers = from caliber in ((BrassService)this.service).GetCalibers()
                           orderby caliber.SortOrder
                           select caliber;

            ViewBag.CaliberId = new SelectList(calibers, "Id", "Name");
            ViewBag.ParentId = new SelectList(this.brassViews, "Id", "BrassName");
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name");
            ViewBag.MaterialId = new SelectList(this.materials, "Id", "Name");
            ViewBag.LengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation");

            return base.Create();
        }

        public ActionResult Clone(int? id)
        {
            ((BrassService)this.service).Clone((int)id);

            return RedirectToAction("Index");
        }

        // POST: /Brass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,CaliberId,ParentId,Length,LengthUnitId,MaterialId,ManufacturerId,TimesFired,Notes")] Brass modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.CaliberId = new SelectList(this.calibers, "Id", "Name", modEntity.CaliberId);
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.ManufacturerId);
            ViewBag.MaterialId = new SelectList(this.materials, "Id", "Name", modEntity.MaterialId);
            ViewBag.LengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", modEntity.Caliber.BrassLengthUnitId);

            return View(modEntity);
        }

        // GET: /Brass/Edit/5
        public override ActionResult Edit(int? id)
        {
            this.getEntity((int)id);

            using (var localEntity = this.entity as Brass)
            {
                ViewBag.CaliberId = new SelectList(this.calibers, "Id", "Name", localEntity.CaliberId);
                ViewBag.ParentId = new SelectList(this.brassViews.Where(b => b.CaliberId == localEntity.CaliberId), "Id", "BrassFullName", localEntity.ParentId);
                ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", localEntity.ManufacturerId);
                ViewBag.MaterialId = new SelectList(this.materials, "Id", "Name", localEntity.MaterialId);
                ViewBag.LengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", localEntity.Caliber.BrassLengthUnitId);
            }

            return base.Edit(id);
        }

        // POST: /Brass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,CaliberId,Length,LengthUnitId,MaterialId,ManufacturerId,TimesFired,Notes")] Brass modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.CaliberId = new SelectList(this.calibers, "Id", "Name", modEntity.CaliberId);
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.ManufacturerId);
            ViewBag.MaterialId = new SelectList(this.materials, "Id", "Name", modEntity.MaterialId);
            ViewBag.LengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", modEntity.Caliber.BrassLengthUnitId);

            return View(modEntity);
        }

        public override ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entityViewModel = new BrassViewModel();
            var entity = this.brasses.OfType<Brass>().Where(b => b.Id == (int)id).First(); //localService.FindById(id) as Brass;

            var entityView = this.brassViews.Where(b => b.Id == (int)id).First(); //new BrassView { ManufacturerName = entity.Manufacturer.Name, MaterialName = entity.Material.Name, CaliberViewName = entity.Caliber.Name, LengthUnitViewAbbreviation = entity.LengthUnit.Abbreviation };

            entityViewModel.Entity = entity;
            entityViewModel.EntityView = entityView;

            return View(entityViewModel);
        }

        public override ActionResult Delete(int? id)
        {
            var entityViewModel = new BrassViewModel();
            var entity = this.brasses.OfType<Brass>().Where(b => b.Id == (int)id).First();
            var entityView = this.brassViews.Where(b => b.Id == (int)id).First();

            entityViewModel.CanDelete = !(entity.Cartridges.Any() || entity.BrassQuantities.Any() || entity.BrassCosts.Any());
            entityViewModel.Entity = entity;
            entityViewModel.EntityView = entityView;

            return View(entityViewModel);
        }

    }
}
