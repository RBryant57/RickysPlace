using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;
using ShootingManager.Service;
using ShootingManager.Service.Interfaces;
using ShootingManager.Web.ViewModels;

namespace ShootingManager.Web.Controllers
{
    public class InventoryController : ShootingManagerBaseController
    {

        #region Local Services

        private IBrassService brassService;
        private IBulletService bulletService;
        private ICartridgeService cartridgeService;
        private ICartridgeLoadService cartridgeLoadService;
        private IPrimerService primerService;
        private IPowderService powderService;

        #endregion

        #region Constructors
        public InventoryController()
        {
            this.brassService = new BrassService();
            this.bulletService = new BulletService();
            this.cartridgeLoadService = new CartridgeLoadService();
            this.cartridgeService = new CartridgeService();
            this.powderService = new PowderService();
            this.primerService = new PrimerService();
        }

        public InventoryController(IBrassService iBrassService, IBulletService iBulletService, ICartridgeLoadService iCartridgeLoadService, ICartridgeService iCartridgeService, IPowderService iPowderService, IPrimerService iPrimerService)
        {
            this.brassService = iBrassService;
            this.bulletService = iBulletService;
            this.cartridgeLoadService = iCartridgeLoadService;
            this.cartridgeService = iCartridgeService;
            this.powderService = iPowderService;
            this.primerService = iPrimerService;
        }

        #endregion

        #region Private Methods
        private void changeInventory(IInventoryEntity changeEntity, IAccountingEntity costEntity, IManagementService service)
        {
            Unit quan = new Unit();
            quan = (changeEntity is PowderQuantity) ? this.massUnits.OfType<Unit>().Where(u => u.Abbreviation == "mgr.").First() : this.primerService.GetQuantityUnits().OfType<Unit>().Where(u => u.Abbreviation == "ea.").First();

            if(changeEntity.QuantityUnitId != 0 && changeEntity.QuantityUnitId != quan.Id)
            {
                switch((this.massUnits.OfType<Unit>().Where(u => u.Id == changeEntity.QuantityUnitId).First() as Unit).Abbreviation)
                {
                    case "lbs.":
                        changeEntity.Change *= 7000000;
                        break;
                    case "gr.":
                        changeEntity.Change *= 1000;
                        break;
                    case "oz.":
                        changeEntity.Change *= 437500;
                        break;
                }
            }

            changeEntity.QuantityUnitId = quan.Id;
            changeEntity.StartQuantity = changeEntity.EndQuantity;
            changeEntity.EndQuantity = changeEntity.EndQuantity + changeEntity.Change;
            service.AddQuantity(changeEntity);

            var cost = Request.Form["Cost"];
            if (!String.IsNullOrEmpty(cost))
            {
                costEntity.EntityId = changeEntity.EntityId;
                costEntity.Date = changeEntity.Date;
                costEntity.Quantity = changeEntity.Change;
                costEntity.QuantityUnitId = changeEntity.QuantityUnitId;
                costEntity.Cost = Convert.ToDecimal(cost);
                service.AddCost(costEntity);
            }
        }

        #endregion

        #region Indexes
        //
        // GET: /Inventory/
        public override ActionResult Index(int? id)
        {
            ViewBag.Environment = ConfigurationManager.AppSettings.Get("Environment");
            return View();
        }

        public ActionResult BrassIndex()
        {
            var entityQuantities = from eq in this.brassService.GetAllQuantities().OfType<BrassQuantity>()
                                  group eq by eq.EntityId into e
                                  orderby e.Key
                                  select e;

            var entityIndexViews = new List<BrassViewModel>();
            
            foreach(var oeq in entityQuantities.ToList())
            {
                var bq = oeq.OrderByDescending(p => p.Date).First();
                var entityView = this.brassViews.Where(e => e.Id == bq.EntityId).First();

                if(bq.EndQuantity != 0)
                    entityIndexViews.Add(new BrassViewModel { EntityQuantity = bq, EntityView = entityView });
            }

            return View(entityIndexViews.OrderBy(b => b.EntityQuantity.Brass.CaliberId).ToList());
        }

        public ActionResult BulletIndex()
        {
            var entityQuantities = from eq in this.bulletService.GetAllQuantities().OfType<BulletQuantity>()
                                  group eq by eq.EntityId into e
                                  orderby e.Key
                                  select e;

            var entityIndexViews = new List<BulletViewModel>();

            foreach (var oeq in entityQuantities.ToList())
            {
                var eq = oeq.OrderByDescending(p => p.Date).First();
                var entityView = this.bulletViews.Where(e => e.Id == eq.EntityId).First();

                if (eq.EndQuantity != 0)
                    entityIndexViews.Add(new BulletViewModel { EntityQuantity = eq, EntityView = entityView });
            }

            return View(entityIndexViews.OrderBy(b => b.EntityQuantity.Bullet.Diameter).ToList());
        }

        public ActionResult CartridgeIndex()
        {
            var entityQuantities = from eq in this.cartridgeService.GetAllQuantities().OfType<CartridgeQuantity>()
                                   group eq by eq.EntityId into e
                                   orderby e.Key
                                   select e;

            var entityIndexViews = new List<CartridgeViewModel>();

            foreach (var oeq in entityQuantities.ToList())
            {
                var eq = oeq.OrderByDescending(p => p.Date).First();
                var primerView = this.cartridgeViews.Where(e => e.Id == eq.EntityId).First();

                if (eq.EndQuantity != 0)
                    entityIndexViews.Add(new CartridgeViewModel { EntityQuantity = eq, EntityView = primerView });
            }

            return View(entityIndexViews.OrderBy(b => b.EntityView.CartridgeLoadViewCaliberViewSortOrder).ToList());
        }

        public ActionResult PowderIndex()
        {
            var entityQuantities = from eq in this.powderService.GetAllQuantities().OfType<PowderQuantity>()
                                   group eq by eq.EntityId into e
                                   orderby e.Key
                                   select e;

            var entityIndexViews = new List<PowderViewModel>();

            foreach (var oeq in entityQuantities.ToList())
            {
                var eq = oeq.OrderByDescending(p => p.Date).First();
                var entityView = this.powderViews.Where(e => e.Id == eq.EntityId).First();

                if (eq.EndQuantity != 0)
                {
                    var amount = (decimal)eq.EndQuantity;
                    amount = amount / 7000000m;
                    entityIndexViews.Add(new PowderViewModel { EntityQuantity = eq, EntityView = entityView, EntityQuantityAmount = amount });
                }
            }

            return View(entityIndexViews.OrderBy(b => b.EntityQuantity.Powder.Name).ToList());
        }

        public ActionResult PrimerIndex()
        {
            var entityQuantities = from eq in this.primerService.GetAllQuantities().OfType<PrimerQuantity>()
                                   group eq by eq.EntityId into e
                                   orderby e.Key
                                   select e;

            var entityIndexViews = new List<PrimerViewModel>();

            foreach (var oeq in entityQuantities.ToList())
            {
                var eq = oeq.OrderByDescending(p => p.Date).First();
                var entityView = this.primerViews.Where(e => e.Id == eq.EntityId).First();

                if (eq.EndQuantity != 0)
                    entityIndexViews.Add(new PrimerViewModel { EntityQuantity = eq, EntityView = entityView });
            }

            return View(entityIndexViews.OrderBy(b => b.EntityQuantity.Primer.Name).ToList());
        }

        #endregion

        #region Brass
        public ActionResult CreateBrass()
        {
            var finalBrasses = this.brassService.GetAllQuantityViewsWithNoInventory();
            ViewBag.EntityId = new SelectList(finalBrasses, "Id", "BrassName");
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");

            return View();
        }
        public ActionResult EditBrass(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = this.brassQuantities.Where(bq => bq.Id == (int)id).First();
            if (entity == null)
            {
                return HttpNotFound();
            }

            //entity.Date = DateTime.Now;
            entity.Change = 0;
            ViewBag.BrassName = this.brassViews.Where(bv => bv.Id == entity.Brass.Id).First().BrassName;
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeBrass([Bind(Include="EntityId,InventoryTypeId,EndQuantity,Change,Date")]BrassQuantity entity)
        {
            if (ModelState.IsValid)
            {
                //entity.StartQuantity = Convert.ToInt32(((ServiceBase)this.brassService).GetQuantity(entity.EntityId));
                //entity.EndQuantity = entity.StartQuantity + entity.Change;
                //var quan = this.quantityUnits.First() as Unit;
                //entity.QuantityUnitId = quan.Id;
                //((ServiceBase)this.brassService).AddQuantity(entity);

                //var cost = Request.Form["Cost"];
                //if (!String.IsNullOrEmpty(cost))
                //{
                //    var entityCost = new BrassCost();
                //    entityCost.EntityId = entity.EntityId;
                //    entityCost.Date = entity.Date;
                //    entityCost.Quantity = entity.Change;
                //    entityCost.QuantityUnitId = entity.QuantityUnitId;
                //    entityCost.Cost = Convert.ToDecimal(cost);
                //    ((ServiceBase)this.brassService).AddCost(entityCost);
                //}

                this.changeInventory(entity, new BrassCost(), this.brassService);
                return RedirectToAction("BrassIndex");
            }

            var brasses = from brass in this.brassService.GetBrassViews()
                          where !(from q in this.brassService.GetAllQuantities().OfType<BrassQuantity>()
                                  select q.EntityId).Contains(brass.Id)
                          select brass;

            ViewBag.EntityId = new SelectList(brasses, "BrassId", "BrassFullName");
            return View();
        }

        #endregion

        #region Bullet
        public ActionResult CreateBullet()
        {
            var finalBullets = this.bulletService.GetAllQuantityViewsWithNoInventory();
            ViewBag.EntityId = new SelectList(finalBullets, "Id", "BulletFullName");
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");

            return View();
        }
        public ActionResult EditBullet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = this.bulletQuantities.Where(bq => bq.Id == (int)id).First();
            if (entity == null)
            {
                return HttpNotFound();
            }

            entity.Change = 0;
            ViewBag.BulletName = this.bulletViews.Where(bv => bv.Id == entity.Bullet.Id).First().BulletFullName;
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeBullet([Bind(Include = "EntityId,InventoryTypeId,EndQuantity,Change,Date")]BulletQuantity entity)
        {
            if (ModelState.IsValid)
            {
                this.changeInventory(entity, new BulletCost(), this.bulletService);
                return RedirectToAction("BulletIndex");
            }

            var bullets = from bullet in this.bulletService.GetBulletViews()
                          where !(from q in this.bulletService.GetAllQuantities().OfType<BulletQuantity>()
                                  select q.EntityId).Contains(bullet.Id)
                          select bullet;

            ViewBag.EntityId = new SelectList(bullets, "BulletId", "BulletFullName");
            return View();
        }

        #endregion

        #region Powder
        public ActionResult CreatePowder()
        {
            var finalPowders = this.powderService.GetAllQuantityViewsWithNoInventory();
            ViewBag.EntityId = new SelectList(finalPowders, "Id", "PowderName");
            ViewBag.QuantityUnitId = new SelectList(this.massUnits, "Id", "Abbreviation");
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");

            return View();
        }
        public ActionResult EditPowder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = this.powderQuantities.Where(bq => bq.Id == (int)id).First();
            if (entity == null)
            {
                return HttpNotFound();
            }

            entity.Change = 0;
            ViewBag.PowderName = this.powderViews.Where(bv => bv.Id == entity.Powder.Id).First().PowderName;
            ViewBag.QuantityUnitId = new SelectList(this.massUnits, "Id", "Abbreviation");
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePowder([Bind(Include = "EntityId,InventoryTypeId,QuantityUnitId,EndQuantity,Change,Date")]PowderQuantity entity)
        {
            if (ModelState.IsValid)
            {
                this.changeInventory(entity, new PowderCost(), this.powderService);
                return RedirectToAction("PowderIndex");
            }

            var powders = from powder in this.powderService.GetPowderViews()
                          where !(from q in this.powderService.GetAllQuantities().OfType<PowderQuantity>()
                                  select q.EntityId).Contains(powder.Id)
                          select powder;

            ViewBag.EntityId = new SelectList(powders, "PowderId", "PowderName");
            return View();
        }

        #endregion

        #region Primer
        public ActionResult CreatePrimer()
        {
            var finalPrimers = this.primerService.GetAllQuantityViewsWithNoInventory();
            ViewBag.EntityId = new SelectList(finalPrimers, "Id", "PrimerName");
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");

            return View();
        }
        public ActionResult EditPrimer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = this.primerQuantities.Where(bq => bq.Id == (int)id).First();
            if (entity == null)
            {
                return HttpNotFound();
            }

            entity.Change = 0;
            ViewBag.PrimerName = this.primerViews.Where(bv => bv.Id == entity.Primer.Id).First().PrimerFullName;
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePrimer([Bind(Include = "EntityId,InventoryTypeId,EndQuantity,Change,Date")]PrimerQuantity entity)
        {
            if (ModelState.IsValid)
            {
                this.changeInventory(entity, new PrimerCost(), this.primerService);
                return RedirectToAction("PrimerIndex");
            }

            var primers = from primer in this.primerService.GetPrimerViews()
                          where !(from q in this.primerService.GetAllQuantities().OfType<PrimerQuantity>()
                                  select q.EntityId).Contains(primer.Id)
                          select primer;

            ViewBag.EntityId = new SelectList(primers, "PrimerId", "PrimerFullName");
            return View();
        }

        #endregion

        #region Cartridge

        public ActionResult CreateCartridge()
        {
            var finalEntities = this.cartridgeService.GetAllQuantityViewsWithNoInventory();
            ViewBag.EntityId = new SelectList(finalEntities, "Id", "CartridgeName");
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");
            ViewBag.BrassId = new SelectList(this.brassViews, "Id", "BrassName");
            ViewBag.PrimerId = new SelectList(this.primerViews, "Id", "PrimerName");

            return View();
        }

        public ActionResult EditCartridge(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = this.cartridgeQuantities.Where(bq => bq.Id == (int)id).First();
            if (entity == null)
            {
                return HttpNotFound();
            }

            entity.Change = 0;
            ViewBag.CartridgeName = this.cartridgeViews.Where(bv => bv.Id == entity.Cartridge.Id).First().CartridgeName;
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");
            ViewBag.BrassId = new SelectList(this.brassViews, "Id", "BrassName");
            ViewBag.PrimerId = new SelectList(this.primerViews, "Id", "PrimerName");

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeCartridge([Bind(Include = "EntityId,InventoryTypeId,EndQuantity,Change,Date")]CartridgeQuantity entity)
        {
            if (ModelState.IsValid)
            {
                var cost = Request.Form["Cost"];
                if (!String.IsNullOrEmpty(cost))
                {
                    this.changeInventory(entity, new CartridgeCost(), this.cartridgeService);
                    return RedirectToAction("CartridgeIndex");
                }

                using (var transaction = new TransactionScope())
                {
                    try
                    {
                        var cartridgeColl = from cartridge in this.cartridgeService.GetAll().OfType<Cartridge>()
                                            where cartridge.Id == entity.EntityId
                                            select cartridge;
                        var singleCartridge = cartridgeColl.First();
                        var quan = this.cartridgeService.GetQuantityUnits().OfType<Unit>().Where(u => u.Abbreviation == "ea.").First();
                        var negChange = entity.Change * -1;

                        entity.QuantityUnitId = quan.Id;
                        entity.StartQuantity = entity.EndQuantity;
                        entity.EndQuantity = entity.EndQuantity + entity.Change;
                        this.cartridgeService.AddQuantity(entity);

                        var brassQ = this.brassService.GetAllQuantities().OfType<BrassQuantity>().Where(b => b.EntityId == singleCartridge.BrassId).OrderByDescending(b => b.Date).First();
                        var newBrassQ = new BrassQuantity();
                        newBrassQ.EntityId = brassQ.EntityId;
                        newBrassQ.Date = entity.Date;
                        newBrassQ.Change = negChange;
                        newBrassQ.InventoryTypeId = entity.InventoryTypeId;
                        newBrassQ.StartQuantity = brassQ.EndQuantity;
                        newBrassQ.EndQuantity = (brassQ.EndQuantity - entity.Change);
                        newBrassQ.QuantityUnitId = quan.Id;
                        this.brassService.AddQuantity(newBrassQ);

                        var bulletQ = this.bulletService.GetAllQuantities().OfType<BulletQuantity>().Where(b => b.EntityId == singleCartridge.CartridgeLoad.BulletId).OrderByDescending(b => b.Date).First();
                        var newBulletQ = new BulletQuantity();
                        newBulletQ.EntityId = bulletQ.EntityId;
                        newBulletQ.Date = entity.Date;
                        newBulletQ.Change = negChange;
                        newBulletQ.InventoryTypeId = entity.InventoryTypeId;
                        newBulletQ.StartQuantity = bulletQ.EndQuantity;
                        newBulletQ.EndQuantity = (bulletQ.EndQuantity - entity.Change);
                        newBulletQ.QuantityUnitId = quan.Id;
                        this.bulletService.AddQuantity(newBulletQ);

                        var primerQ = this.primerService.GetAllQuantities().OfType<PrimerQuantity>().Where(p => p.EntityId == singleCartridge.PrimerId).OrderByDescending(p => p.Date).First();
                        var newPrimerQ = new PrimerQuantity();
                        newPrimerQ.EntityId = primerQ.EntityId;
                        newPrimerQ.Date = entity.Date;
                        newPrimerQ.Change = negChange;
                        newPrimerQ.InventoryTypeId = entity.InventoryTypeId;
                        newPrimerQ.StartQuantity = primerQ.EndQuantity;
                        newPrimerQ.EndQuantity = (primerQ.EndQuantity - entity.Change);
                        newPrimerQ.QuantityUnitId = quan.Id;
                        this.primerService.AddQuantity(newPrimerQ);

                        var powderQ = this.powderService.GetAllQuantities().OfType<PowderQuantity>().Where(p => p.EntityId == singleCartridge.CartridgeLoad.PowderId).OrderByDescending(p => p.Date).First();
                        var cartridgeLoad = this.cartridgeLoadService.GetAll().OfType<CartridgeLoad>().Where(c => c.Id == singleCartridge.CartridgeLoad.Id).First();
                        var powderChange = (int)(entity.Change * cartridgeLoad.PowderWeight);
                        var newPowderQ = new PowderQuantity();
                        newPowderQ.EntityId = powderQ.EntityId;
                        newPowderQ.Date = entity.Date;
                        newPowderQ.Change = powderChange * -1;
                        newPowderQ.InventoryTypeId = entity.InventoryTypeId;
                        newPowderQ.StartQuantity = powderQ.EndQuantity;
                        newPowderQ.EndQuantity = (powderQ.EndQuantity - powderChange);
                        newPowderQ.QuantityUnitId = powderQ.QuantityUnitId;
                        this.powderService.AddQuantity(newPowderQ);

                        transaction.Complete();
                    }
                    catch
                    {

                    }
                }

                return RedirectToAction("CartridgeIndex");
            }

            var finalEntities = this.cartridgeService.GetAllQuantityViewsWithNoInventory();
            ViewBag.EntityId = new SelectList(finalEntities, "Id", "CartridgeName");
            ViewBag.InventoryTypeId = new SelectList(this.inventoryTypes, "Id", "Description");
            ViewBag.BrassId = new SelectList(this.brassViews, "Id", "BrassName");
            ViewBag.PrimerId = new SelectList(this.primerViews, "Id", "PrimerName");

            return View();
        }

        #endregion

    }
}