using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

using ShootingManager.Entities.Models;
using ShootingManager.Service;
using ShootingManager.Service.Interfaces;
using ShootingManager.Web.ViewModels;
using Web.Core;

namespace ShootingManager.Web.Controllers
{
    public class GunController : ShootingManagerBaseController
    {
        public GunController()
        {
            this.service = new GunService();
        }

        public GunController(IGunService igunService)
        {
            this.service = igunService;
        }

        public override ActionResult Index(int? id)
        {
            var entityViewModels = new List<GunViewModel>();
            IEnumerable<GunView> entityViews;

            using (var localService = this.service as IGunService)
            {
                if (id != null)
                {
                    entityViews = from entityView in localService.GetGunViews()
                                  where entityView.CaliberId == id
                                  select entityView;
                    ViewBag.CaliberName = entityViews.First().CaliberViewName;
                }
                else
                {
                    entityViews = localService.GetGunViews().OrderBy(gv => gv.CaliberViewSortOrder).ThenBy(gv => gv.Name);
                    ViewBag.CaliberName = "All Calibers";
                }

                foreach (GunView entityView in entityViews)
                {
                    var entityViewModel = new GunViewModel();

                    entityViewModel.Entity = this.guns.OfType<Gun>().Where(g => g.Id == entityView.Id).First();
                    entityViewModel.EntityView = entityView;
                    entityViewModels.Add(entityViewModel);
                }
            }

            return View(entityViewModels);
        }

        // GET: /Gun/Details/5
        public override ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entityViewModel = new GunViewModel();
            using (var localService = this.service as IGunService)
            {
                var entity = localService.GetAll().OfType<Gun>().Where(b => b.Id == id).First();

                var entityView = localService.GetGunViews().Where(g => g.Id == id).First();
                //entityView.AdditionalCalibers = localService.GetGunsCalibersViews().Where(g => g.GunId == id).Select(c => new CaliberStruct() { c.CaliberId, c.CaliberName }).ToList();
                //var cals = localService.GetGunsCalibersViews().Where(g => g.GunId == id).Select(c => new CaliberInfo { Id = c.CaliberId, Name = c.CaliberName }).ToList();
                //var calStructList = new List<CaliberInfo>();
                //foreach (var cal in cals)
                //{
                //    var calStruct = new CaliberInfo();

                //    calStruct.Id = cal.CaliberId;
                //    calStruct.Name = cal.CaliberName;
                //    calStructList.Add(calStruct);
                //}
                //entityView.AdditionalCalibers = cals;

                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

        // GET: /Gun/Create
        public override ActionResult Create()
        {
            ViewBag.BarrelLengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation");
            ViewBag.CaliberId = new SelectList(this.calibers, "Id", "Name");
            ViewBag.CalibersId = new SelectList(this.calibers, "Id", "Name");
            ViewBag.GunTypeId = new SelectList(this.gunTypes, "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name");
            ViewBag.SellerId = new SelectList(this.manufacturers, "Id", "Name");
            ViewBag.BuyerId = new SelectList(this.manufacturers, "Id", "Name");

            return base.Create();
        }

        // POST: /Gun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,SerialNumber,Name,CaliberId,ManufacturerId,Capacity,BarrelLength,BarrelLengthUnitId,GunTypeId,Cost,AcquisitionDate,SellerId,RetireDate,BuyerId,Details,Notes")] Gun modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.LengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", modEntity.BarrelLengthUnitId);
            ViewBag.CaliberId = new SelectList(this.calibers, "Id", "Name", modEntity.CaliberId);
            ViewBag.GunTypeId = new SelectList(this.gunTypes, "Id", "Name", modEntity.GunTypeId);
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.ManufacturerId);
            ViewBag.SellerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.SellerId);
            ViewBag.BuyerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.BuyerId);

            return View(modEntity);
        }

        // GET: /Gun/Edit/5
        public override ActionResult Edit(int? id)
        {
            this.getEntity((int)id);

            using (var localEntity = this.entity as Gun)
            {
                ViewBag.BarrelLengthUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", localEntity.BarrelLengthUnitId);
                ViewBag.CaliberId = new SelectList(this.calibers, "Id", "Name", localEntity.CaliberId);
                ViewBag.GunTypeId = new SelectList(this.gunTypes, "Id", "Name", localEntity.GunTypeId);
                ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", localEntity.ManufacturerId);
                ViewBag.SellerId = new SelectList(this.manufacturers, "Id", "Name", localEntity.SellerId);
                ViewBag.BuyerId = new SelectList(this.manufacturers, "Id", "Name", localEntity.BuyerId);
            }

            return base.Edit(id);
        }

        // POST: /Gun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include= "Id,SerialNumber,Name,CaliberId,ManufacturerId,Capacity,BarrelLength,BarrelLengthUnitId,GunTypeId,Cost,AcquisitionDate,SellerId,RetireDate,BuyerId,Details,Notes")] Gun modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.LengthUnitID = new SelectList(this.lengthUnits, "Id", "Abbreviation", modEntity.BarrelLengthUnitId);
            ViewBag.CaliberId = new SelectList(this.calibers, "Id", "Name", modEntity.CaliberId);
            ViewBag.GunTypeId = new SelectList(this.gunTypes, "Id", "Name", modEntity.GunTypeId);
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.ManufacturerId);
            ViewBag.SellerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.SellerId);
            ViewBag.BuyerId = new SelectList(this.manufacturers, "Id", "Name", modEntity.BuyerId);

            return View(modEntity);
        }

        public override ActionResult Delete(int? id)
        {
            var entityViewModel = new GunViewModel();
            using (var localService = this.service as IGunService)
            {
                var entity = localService.GetAll().OfType<Gun>().Where(b => b.Id == id).First();

                var entityView = new GunView { CaliberViewName = entity.Caliber.Name, ManufacturerName = entity.Manufacturer.Name, GunTypeName = entity.GunType.Name, LengthUnitViewAbbreviation = entity.BarrelLengthUnit.Abbreviation };

                entityViewModel.CanDelete = !(entity.GunImages.Any() || entity.ShootingSessions.Any());
                entityViewModel.Entity = entity;
                entityViewModel.EntityView = entityView;
            }

            return View(entityViewModel);
        }

    }
}
