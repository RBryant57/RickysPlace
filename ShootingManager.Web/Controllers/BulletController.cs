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
    public class BulletController : ShootingManagerBaseController
    {

        public BulletController()
        {
            this.service = new BulletService();            
        }

        public BulletController(IBulletService ibulletService)
        {
            this.service = ibulletService;            
        }

        public override ActionResult Index(int? id)
        {
            var entityViewModels = new List<BulletViewModel>();
            IEnumerable<BulletView> entityViews;

            using (var localService = this.service as IBulletService)
            {
                if (id != null)
                {
                    entityViews = from entityView in localService.GetBulletViews().ToList()
                                 where entityView.CaliberViewId == id
                                 select entityView;
                    ViewBag.CaliberName = entityViews.First().CaliberViewName;
                }
                else
                {
                    entityViews = localService.GetBulletViews().ToList();
                    ViewBag.CaliberName = "All Calibers";
                }

                foreach (BulletView entityView in entityViews.OrderBy(ev => ev.CaliberViewSortOrder).ThenBy(ev => ev.Mass).ThenBy(ev => ev.Name))
                {
                    var entityViewModel = new BulletViewModel();
                    var entity = new Bullet { Id = entityView.Id, Name = entityView.Name, BulletTypeId = entityView.BulletTypeId, MaterialId = entityView.MaterialId, Diameter = entityView.Diameter, DiameterUnitId = entityView.DiameterUnitId, Mass = entityView.Mass, MassUnitId = entityView.MassUnitId, SectionalDensity = entityView.SectionalDensity, BallisticCoefficient = entityView.BallisticCoefficient, Length = entityView.Length, LengthUnitId = entityView.LengthUnitId, ManufacturerId = entityView.ManufacturerId, Notes = entityView.Notes };

                    entityViewModel.Entity = entity;
                    entityViewModel.EntityView = entityView;
                    entityViewModels.Add(entityViewModel);
                }
            }

            return View(entityViewModels);

        }

        // GET: /Bullet/Create
        public override ActionResult Create()
        {
            using (var localService = this.service as IBulletService)
            {
                ViewBag.BulletTypeId = new SelectList(this.bulletTypes, "Id", "Abbreviation");
                ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name");
                ViewBag.MaterialId = new SelectList(this.materials, "Id", "Name");
            }
            
            ViewBag.DiameterUnitId = new SelectList(this.lengthUnits.ToList(), "Id", "Abbreviation");
            ViewBag.LengthUnitId = new SelectList(this.lengthUnits.ToList(), "Id", "Abbreviation");
            ViewBag.MassUnitId = new SelectList(this.massUnits.ToList(), "Id", "Abbreviation");

            return base.Create();
        }

        // POST: /Bullet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,BulletTypeId,CaliberId,MaterialId,Diameter,DiameterUnitId,Length,LengthUnitId,Mass,MassUnitId,SectionalDensity,BallisticCoefficient,ManufacturerId,Notes")] Bullet modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                return RedirectToAction("Index");
            }

            using (var localService = this.service as IBulletService)
            {
                ViewBag.BulletTypeId = new SelectList(this.bulletTypes, "Id", "Abbreviation", modEntity.BulletTypeId);
                ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.ManufacturerId);
                ViewBag.MaterialId = new SelectList(this.materials, "Id", "Name", modEntity.MaterialId);
            }
            
            ViewBag.DiameterUnitId = new SelectList(this.lengthUnits.ToList(), "Id", "Abbreviation", modEntity.DiameterUnitId);
            ViewBag.LengthUnitId = new SelectList(this.lengthUnits.ToList(), "Id", "Abbreviation", modEntity.LengthUnitId);
            ViewBag.MassUnitId = new SelectList(this.massUnits.ToList(), "Id", "Abbreviation", modEntity.MassUnitId);

            return View(modEntity);
        }

        // GET: /Bullet/Edit/5
        public override ActionResult Edit(int? id)
        {
            this.getEntity((int)id);

            using (var localEntity = this.entity as Bullet)
            {
                using (var localService = this.service as IBulletService)
                {
                    ViewBag.BulletTypeId = new SelectList(this.bulletTypes, "Id", "Abbreviation", localEntity.BulletTypeId);
                    ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", localEntity.ManufacturerId);
                    ViewBag.MaterialId = new SelectList(this.materials, "Id", "Name", localEntity.MaterialId);
                }
                ViewBag.DiameterUnitId = new SelectList(this.lengthUnits.ToList(), "Id", "Abbreviation", localEntity.DiameterUnitId);
                ViewBag.LengthUnitId = new SelectList(this.lengthUnits.ToList(), "Id", "Abbreviation", localEntity.LengthUnitId);
                ViewBag.MassUnitId = new SelectList(this.massUnits.ToList(), "Id", "Abbreviation", localEntity.MassUnitId);
            }

            return base.Edit(id);
        }

        // POST: /Bullet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,BulletTypeId,MaterialId,Diameter,DiameterUnitId,SectionalDensity,BallisticCoefficient,Length,LengthUnitId,Mass,MassUnitId,ManufacturerId,Notes")] Bullet modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(modEntity);
                return RedirectToAction("Index");
            }

            using (var localService = this.service as IBulletService)
            {
                ViewBag.BulletTypeId = new SelectList(this.bulletTypes, "Id", "Abbreviation", modEntity.BulletTypeId);
                ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.ManufacturerId);
                ViewBag.MaterialId = new SelectList(this.materials, "Id", "Name", modEntity.MaterialId);
            }
            
            ViewBag.DiameterUnitId = new SelectList(this.lengthUnits.ToList(), "Id", "Abbreviation", modEntity.DiameterUnitId);
            ViewBag.LengthUnitId = new SelectList(this.lengthUnits.ToList(), "Id", "Abbreviation", modEntity.LengthUnitId);
            ViewBag.MassUnitId = new SelectList(this.massUnits.ToList(), "Id", "Abbreviation", modEntity.MassUnitId);

            return View(modEntity);

        }

        public override ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entityView = new BulletViewModel();
            using (var localService = this.service as IBulletService)
            {
                var entity = localService.GetBulletViews().Where(b => b.Id == id).First() as BulletView;

                var newEntity = new Bullet { Id = entity.Id, Name = entity.Name, BulletTypeId = entity.BulletTypeId, MaterialId = entity.MaterialId, Diameter = entity.Diameter, DiameterUnitId = entity.DiameterUnitId, Mass = entity.Mass, MassUnitId = entity.MassUnitId, SectionalDensity = entity.SectionalDensity, BallisticCoefficient = entity.BallisticCoefficient, Length = entity.Length, LengthUnitId = entity.LengthUnitId, ManufacturerId = entity.ManufacturerId, Notes = entity.Notes };

                entityView.Entity = newEntity;
                entityView.EntityView = entity;
            }

            return View(entityView);
        }

        public override ActionResult Delete(int? id)
        {
            var entityViewModel = new BulletViewModel();
            using (var localService = this.service as IBulletService)
            {
                var entity = localService.FindById(id) as Bullet;
                var entityView = new BulletView { Id = entity.Id, Name = entity.Name, BulletTypeAbbreviation = entity.BulletType.Abbreviation, MaterialId = entity.MaterialId, MaterialName = entity.Material.Name, Diameter = entity.Diameter, DiameterUnitId = entity.DiameterUnitId, Mass = entity.Mass, MassUnitId = entity.MassUnitId, SectionalDensity = entity.SectionalDensity, BallisticCoefficient = entity.BallisticCoefficient, Length = entity.Length, LengthUnitId = entity.LengthUnitId, ManufacturerId = entity.ManufacturerId, ManufacturerName = entity.Manufacturer.Name, Notes = entity.Notes };

                entityViewModel.CanDelete = !(entity.CartridgeLoads.Any() || entity.BulletQuantities.Any() || entity.BulletCosts.Any());
                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

    }
}
