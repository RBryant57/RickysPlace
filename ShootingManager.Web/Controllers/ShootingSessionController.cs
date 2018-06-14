using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class ShootingSessionController : ShootingManagerBaseController
    {
        ICartridgeService cartridgeService;
        IBrassService brassService;
        public ShootingSessionController()
        {
            this.service = new ShootingSessionService();
            this.cartridgeService = new CartridgeService();
            this.brassService = new BrassService();
        }

        public ShootingSessionController(IShootingSessionService iService, ICartridgeService iCartridgeService, IBrassService iBrassService)
        {
            this.service = iService;
            this.cartridgeService = iCartridgeService;
            this.brassService = iBrassService;
        }

        public override ActionResult Index(int? id)
        {
            var entityViews = new List<ShootingSessionViewModel>();

            using (var localService = this.service as IShootingSessionService)
            {
                foreach (ShootingSession entity in localService.GetAll().OfType<ShootingSession>().OrderBy(e => e.Date))
                {
                    var entityViewModel = new ShootingSessionViewModel();
                    var entityView = new ShootingSessionView { CartridgeViewName = this.cartridgeViews.Where(c => c.Id == entity.Cartridge.Id).First().CartridgeName, GunViewName = this.gunViews.Where(g => g.Id == entity.Gun.Id).First().GunName, ShootingLocationViewName = entity.ShootingLocation.Name + ", " + entity.ShootingLocation.State, ShootingLocationViewState = entity.ShootingLocation.State, Date = entity.Date };

                    entityViewModel.Entity = entity;
                    entityViewModel.EntityView = entityView;

                    entityViews.Add(entityViewModel);
                }
            }

            return View(entityViews);
        }

        public override ActionResult Create()
        {

            ViewBag.LocationId = new SelectList(this.shootingLocationViews, "Id", "ShootingLocationName");
            ViewBag.GunId = new SelectList(this.gunViews.Where(g => g.RetireDate == null), "Id", "GunName");
            //ViewBag.CartridgeId = new SelectList(this.cartridgeViews, "Id", "CartridgeName");

            return base.Create();
        }

        // POST: /Unit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,LocationId,GunId,CartridgeId,Rounds,Retention,Notes")] ShootingSession modEntity)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = new TransactionScope())
                {
                    this.service.Add(modEntity);

                    var cartQuantity = new CartridgeQuantity();
                    cartQuantity.EntityId = modEntity.CartridgeId;
                    cartQuantity.Change = modEntity.Rounds * -1;
                    cartQuantity.Date = modEntity.Date;
                    cartQuantity.StartQuantity = (int)this.cartridgeService.GetQuantity(modEntity.CartridgeId);
                    cartQuantity.EndQuantity = cartQuantity.StartQuantity + cartQuantity.Change;
                    cartQuantity.QuantityUnitId = this.quantityUnits.OfType<Unit>().Where(u => u.Abbreviation == "ea.").First().Id;
                    cartQuantity.InventoryTypeId = this.inventoryTypes.Where(i => i.Description == "Shooting").First().Id;
                    this.cartridgeService.AddQuantity(cartQuantity);

                    if (!(modEntity.Retention == null))
                    {

                        var brassQuantity = new BrassQuantity();
                        var cart = this.cartridgeService.FindById(modEntity.CartridgeId) as Cartridge;
                        var brass = this.brassService.FindById(cart.BrassId) as Brass;
                        var nFiredBrassCollection = this.brasses.OfType<Brass>().Where(b => b.ParentId == brass.Id && b.Id != b.ParentId);
                        var nFiredBrass = new Brass();
                        if (nFiredBrassCollection.Count() == 0)
                        {
                            var newId = this.brassService.Clone(brass.Id);
                            nFiredBrass = this.brassService.FindById(newId) as Brass;
                        }
                        else
                        {
                            nFiredBrass = nFiredBrassCollection.First();
                        }
                        brassQuantity.EntityId = nFiredBrass.Id;
                        brassQuantity.Change = (int)modEntity.Retention;
                        brassQuantity.Date = modEntity.Date;
                        brassQuantity.StartQuantity = (int)this.brassService.GetQuantity(nFiredBrass.Id);
                        brassQuantity.EndQuantity = brassQuantity.StartQuantity + brassQuantity.Change;
                        brassQuantity.QuantityUnitId = this.quantityUnits.OfType<Unit>().Where(u => u.Abbreviation == "ea.").First().Id;
                        brassQuantity.InventoryTypeId = this.inventoryTypes.Where(i => i.Description == "Recycle").First().Id;
                        this.brassService.AddQuantity(brassQuantity);
                    }

                    transaction.Complete();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.LocationId = new SelectList(this.shootingLocationViews, "Id", "ShootingLocationName", modEntity.LocationId);
            ViewBag.GunId = new SelectList(this.gunViews, "Id", "GunName", modEntity.GunId);
            ViewBag.CartridgeId = new SelectList(this.cartridgeViews, "Id", "CartridgeName", modEntity.CartridgeId);

            return View(modEntity);
        }

        // GET: /Unit/Edit/5
        public override ActionResult Edit(int? id)
        {
            this.getEntity((int)id);

            using (var localEntity = this.entity as ShootingSession)
            {
                ViewBag.LocationId = new SelectList(this.shootingLocationViews, "Id", "ShootingLocationName", localEntity.LocationId);
                ViewBag.GunId = new SelectList(this.gunViews, "Id", "GunName", localEntity.GunId);
                ViewBag.CartridgeId = new SelectList(this.cartridgeViews, "Id", "CartridgeName", localEntity.CartridgeId);
            }

            return base.Edit(id);
        }

        // POST: /Unit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,LocationId,GunId,CartridgeId,Rounds,Retention,Notes")] ShootingSession modEntity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(modEntity);
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(this.shootingLocationViews, "Id", "ShootingLocationName", modEntity.LocationId);
            ViewBag.GunId = new SelectList(this.gunViews, "Id", "GunName", modEntity.GunId);
            ViewBag.CartridgeId = new SelectList(this.cartridgeViews, "Id", "CartridgeName", modEntity.CartridgeId);

            return View(modEntity);
        }

        public JsonResult GetCartridges(int gunId)
        {
            var gun = this.guns.OfType<Gun>().Where(g => g.Id == gunId).First();
            var cartridges = this.cartridgeQuantities.Where(c => c.Cartridge.CartridgeLoad.CaliberId == gun.CaliberId);
            var entityQuantities = from eq in this.cartridgeService.GetAllQuantities().OfType<CartridgeQuantity>()
                                   where eq.Cartridge.CartridgeLoad.CaliberId == gun.CaliberId
                                   group eq by eq.EntityId into e
                                   orderby e.Key
                                   select e;
            var cartridgeList = new List<string>();

            foreach(var oeq in entityQuantities.ToList())
            {
                var cart = oeq.OrderByDescending(p => p.Date).First();
                cartridgeList.Add(cart.Cartridge.Id.ToString() + ":" + this.cartridgeViews.Where(c => c.Id == cart.Cartridge.Id).First().CartridgeName);
            }
            //var cartridgeViews = from cart in this.cartridgeViews
            //              where !(from q in this.cartridgeQuantities.OfType<CartridgeQuantity>()
            //                      select q.EntityId).Contains(cart.Id)
            //              select cart;

            

            //foreach (var cl in cartridgeViews)
            //{
            //    cartridgeList.Add(cl.Id.ToString() + ":" + cl.CartridgeName);
            //}
            return Json(cartridgeList);
        }
    }
}