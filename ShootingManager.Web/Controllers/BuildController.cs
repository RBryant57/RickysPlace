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
using ShootingManager.Web.ViewModels;

namespace ShootingManager.Web.Controllers
{
    public class BuildController : ShootingManagerBaseController
    {
        private ICartridgeLoadService cartridgeLoadService;
        private ICartridgeService cartridgeService;
        public CartridgeLoadViewModel cartridgeView { get; set; }

        public BuildController()
        {
            this.cartridgeLoadService = new CartridgeLoadService();
            this.cartridgeService = new CartridgeService();
        }

        public BuildController(ICartridgeLoadService iCartridgeLoadService, ICartridgeService iCartridgeService)
        {
            this.cartridgeLoadService = iCartridgeLoadService;
            this.cartridgeService = iCartridgeService;
        }

        //
        // GET: /Build/
        public override ActionResult Index(int? id)
        {
            ViewBag.Environment = ConfigurationManager.AppSettings.Get("Environment");
            var calibers = this.calibers.OfType<Caliber>();
            return View(calibers.OrderBy(c => c.SortOrder).ToList());
        }

        public ActionResult CartridgeIndex(int? id)
        {
            IEnumerable<Cartridge> finalCartridges;
            IEnumerable<CartridgeView> finalCartridgeViews;

            if (id != null)
            {
                finalCartridges = this.cartridges.OfType<Cartridge>().Where(c => c.CartridgeLoad.CaliberId == (int)id);
                finalCartridgeViews = this.cartridgeViews.OfType<CartridgeView>().Where(c => c.CartridgeLoadViewCaliberId == (int)id);
                ViewBag.CaliberId = id;
                ViewBag.CaliberName = this.calibers.OfType<Caliber>().Where(c => c.Id == (int)id).First().Name;
            }
            else
            {
                finalCartridges = this.cartridges.OfType<Cartridge>();
                finalCartridgeViews = this.cartridgeViews;
                ViewBag.CaliberName = "All Calibers";
            }

            var cartridgeViewModels = new List<CartridgeViewModel>();

            foreach (Cartridge cart in finalCartridges.ToList())
            {
                cartridgeViewModels.Add(new CartridgeViewModel { Entity = cart, EntityView = finalCartridgeViews.Where(cv => cv.Id == cart.Id).First() });
            }

            return View(cartridgeViewModels.OrderBy(cv => cv.EntityView.CartridgeLoadViewCaliberViewSortOrder).ToList());

        }

        public ActionResult LoadIndex(int? id)
        {
            IEnumerable<CartridgeLoad> finalCartridgeLoads;
            IEnumerable<CartridgeLoadView> finalCartridgeLoadViews;

            if (id != null)
            {
                finalCartridgeLoads = this.cartridgeLoads.OfType<CartridgeLoad>().Where(c => c.CaliberId == (int)id);
                finalCartridgeLoadViews = this.cartridgeLoadViews.Where(c => c.CaliberId == (int)id);
                ViewBag.CaliberId = id;
                ViewBag.CaliberName = this.calibers.OfType<Caliber>().Where(c => c.Id == (int)id).First().Name;
            }
            else
            {
                finalCartridgeLoads = this.cartridgeLoads.OfType<CartridgeLoad>();
                finalCartridgeLoadViews = this.cartridgeLoadViews;
                ViewBag.CaliberName = "All Calibers";
            }

            var cartridgeLoadViewModel = new List<CartridgeLoadViewModel>();

            foreach (var cart in finalCartridgeLoads.ToList())
            {
                cartridgeLoadViewModel.Add(new CartridgeLoadViewModel { Entity = cart, EntityView = finalCartridgeLoadViews.Where(cv => cv.Id == cart.Id).First() });
            }

            return View(cartridgeLoadViewModel.OrderBy(clvm => clvm.EntityView.CaliberViewSortOrder).ToList());

        }

        public ActionResult Cartridge(int? id)
        {
            IEnumerable<CartridgeLoadView> finalCartridgeLoads;
            IEnumerable<BrassView> finalBrasses;
            IEnumerable<PrimerView> finalPrimers;

            if (id != null)
            {
                Caliber caliber = this.calibers.OfType<Caliber>().Where(c => c.Id == (int)id).First();
                finalCartridgeLoads = this.cartridgeLoadViews.OfType<CartridgeLoadView>().Where(c => c.CaliberId == (int)id);
                finalBrasses = this.brassViews.Where(b => b.CaliberId == caliber.Id);
                finalPrimers = this.primerViews.Where(p => p.PrimerTypeId == caliber.PrimerTypeId);
                ViewBag.CaliberName = caliber.Name;
            }
            else
            {
                finalCartridgeLoads = this.cartridgeLoadViews.OfType<CartridgeLoadView>();
                finalBrasses = this.brassViews;
                finalPrimers = this.primerViews;
                ViewBag.CaliberId = new SelectList(this.calibers, "Id", "Name");
            }
            
            ViewBag.CartridgeLoadId = new SelectList(finalCartridgeLoads, "Id", "CartridgeLoadName");
            ViewBag.BrassId = new SelectList(finalBrasses, "Id", "BrassName");
            ViewBag.PrimerId = new SelectList(finalPrimers, "Id", "PrimerName");
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cartridge([Bind(Include="Id,Name,CartridgeLoadId,BrassId,TimesLoaded,PrimerId,ManufacturerId,Notes")]Cartridge entity)
        {
            if (ModelState.IsValid)
            {
                this.cartridgeService.Add(entity);
                var cartridgeLoad = this.cartridgeLoadService.FindById(entity.CartridgeLoadId) as CartridgeLoad;
                return RedirectToAction("CartridgeIndex", new {id = cartridgeLoad.CaliberId });
            }

            var cartLoad = this.cartridgeLoadService.FindById(entity.CartridgeLoadId) as CartridgeLoad;
            Caliber caliber = this.calibers.OfType<Caliber>().Where(c => c.Id == cartLoad.CaliberId).First();

            var calibers = this.calibers.OfType<Caliber>().Where(c => c.Id == cartLoad.CaliberId);
            var cartridgeLoads = this.cartridgeLoads.OfType<CartridgeLoad>().Where(c => c.CaliberId == caliber.Id);
            var bullets = this.bulletViews.Where(b => b.CaliberViewId == caliber.Id);
            var brasses = this.brassViews.Where(b => b.CaliberId == caliber.Id);
            var primers = this.primerViews.Where(p => p.Id == caliber.PrimerTypeId);

            ViewBag.CaliberId = new SelectList(calibers, "Id", "Name", caliber.Id);
            ViewBag.CartridgeLoadId = new SelectList(cartridgeLoads, "Id", "Name");
            ViewBag.BulletId = new SelectList(bullets, "BulletId", "BulletName");
            ViewBag.BrassId = new SelectList(brasses, "BrassId", "BrassName");
            ViewBag.PrimerId = new SelectList(primers, "PrimerId", "PrimerName");
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name");

            return View();
        }

        public ActionResult FactoryCartridge(int? id)
        {
            if (id != null)
            {
                Caliber caliber = this.calibers.OfType<Caliber>().Where(c => c.Id == (int)id).First();
                ViewBag.CaliberName = caliber.Name;
            }
            else
            {
                ViewBag.CaliberId = new SelectList(this.calibers, "Id", "Name");
            }

            ViewBag.MassUnitId = new SelectList(this.massUnits, "Id", "Abbreviation");
            ViewBag.BulletTypeId = new SelectList(this.bulletTypes, "Id", "Abbreviation");
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name");
            ViewBag.COLUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation");
            ViewBag.PressureUnitId = new SelectList(this.pressureUnits, "Id", "Abbreviation");
            ViewBag.VelocityUnitId = new SelectList(this.velocityUnits, "Id", "Abbreviation");
            ViewBag.BrassMaterialId = new SelectList(this.materials, "Id", "Name");
            ViewBag.BulletMaterialId = new SelectList(this.materials, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FactoryCartridge([Bind(Include = "Id,Name,CaliberId,MassUnitId,BulletTypeId,ManufacturerId,COLUnitId,PressureUnitId,VelocityUnitId,BrassMaterialId,BulletMaterialId,ManufacturerId,Notes")]Cartridge entity)
        {
            var brass = new Brass();
            var bullet = new Bullet();
            var cartridgeLoad = new CartridgeLoad();

            //brass.Name = entity.Name;
            bullet.Name = entity.Name;
            cartridgeLoad.Name = entity.Name;
            brass.CaliberId = Convert.ToInt32(Request.Form["CaliberId"]);
            cartridgeLoad.CaliberId = Convert.ToInt32(Request.Form["CaliberId"]);
            cartridgeLoad.COL = Convert.ToDecimal(Request.Form["COL"]);
            cartridgeLoad.COLUnitId = Convert.ToInt32(Request.Form["COLUnitId"]);
            if (!String.IsNullOrEmpty(Request.Form["Velocity"]))
            {
                cartridgeLoad.Velocity = Convert.ToInt32(Request.Form["Velocity"]);
                cartridgeLoad.VelocityUnitId = Convert.ToInt32(Request.Form["VelocityUnitId"]);
            }
            if (!String.IsNullOrEmpty(Request.Form["Pressure"]))
            {
                cartridgeLoad.Pressure = Convert.ToInt32(Request.Form["Pressure"]);
                cartridgeLoad.PressureUnitId = Convert.ToInt32(Request.Form["PressureUnitId"]);
            }
            bullet.BulletTypeId = Convert.ToInt32(Request.Form["BulletTypeId"]);
            brass.MaterialId = Convert.ToInt32(Request.Form["BrassMaterialId"]);
            bullet.MaterialId = Convert.ToInt32(Request.Form["BulletMaterialId"]);
            bullet.Mass = Convert.ToInt32(Request.Form["Mass"]);
            bullet.MassUnitId = Convert.ToInt32(Request.Form["MassUnitId"]);
            brass.ManufacturerId = entity.ManufacturerId;
            bullet.ManufacturerId = entity.ManufacturerId;

            if(addFactoryCartridge(brass, bullet, cartridgeLoad, Request.Form["Quantity"] == String.Empty))
                return RedirectToAction("CartridgeIndex");
            else
            {
                ViewBag.CaliberId = new SelectList(this.calibers, "Id", "Name");
                ViewBag.MassUnitId = new SelectList(this.massUnits, "Id", "Abbreviation");
                ViewBag.BulletTypeId = new SelectList(this.bulletTypes, "Id", "Abbreviation");
                ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name");

                return View();
            }
        }

        public ActionResult Load(int? id)
        {

            IEnumerable<BulletView> bullets;
            IEnumerable<PowderView> powders;

            if (id != null)
            {
                Caliber caliber = this.calibers.OfType<Caliber>().Where(c => c.Id == (int)id).First();
                bullets = this.bulletViews.Where(b => b.CaliberViewId == (int)id);

                ViewBag.CaliberName = caliber.Name;
                ViewBag.CaliberId = caliber.Id;
            }
            else
            {
                bullets = this.bulletViews;
                var calibers = this.calibers.OfType<Caliber>().OrderBy(c => c.SortOrder);
                powders = this.powderViews;
                ViewBag.CaliberId = new SelectList(calibers, "Id", "Name");
            }

            ViewBag.BulletId = new SelectList(bullets, "Id", "BulletName");
            ViewBag.PowderId = new SelectList(this.powderViews, "Id", "Name");
            ViewBag.PowderWeightUnitId = new SelectList(this.massUnits.OfType<Unit>().Where(u => u.Abbreviation == "gr."), "Id", "Abbreviation");
            ViewBag.COLUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation");
            ViewBag.VelocityUnitId = new SelectList(this.velocityUnits, "Id", "Abbreviation");
            ViewBag.PressureUnitId = new SelectList(this.pressureUnits, "Id", "Abbreviation");
            
            return View();
        }

        // POST: /Bullet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Load([Bind(Include = "Id,Name,CaliberId,BulletId,PowderId,PowderWeight,PowderWeightUnitId,COL,COLUnitId,Velocity,VelocityUnitId,Pressure,PressureUnitId,Notes")] CartridgeLoad entity)
        {
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(Request.Form["Weight"]))
                {
                    var weight = Convert.ToDecimal(Request.Form["Weight"]) * 1000m;
                    entity.PowderWeight = (int)weight;
                }
                this.cartridgeLoadService.Add(entity);
                return RedirectToAction("LoadIndex", new { id = entity.CaliberId });
            }

            Caliber caliber = this.calibers.OfType<Caliber>().Where(c => c.Id == (int)entity.CaliberId).First();

            ViewBag.CaliberId = caliber;
            ViewBag.BulletId = new SelectList(this.bulletViews.Where(b => b.CaliberViewId == entity.CaliberId) , "BulletId", "BulletName", entity.BulletId);
            ViewBag.PowderId = new SelectList(this.powderViews, "Id", "Name", entity.PowderId);
            ViewBag.PowderWeight = entity.PowderWeight * 1000;
            ViewBag.PowderWeightUnitId = new SelectList(this.massUnits, "Id", "Abbreviation", entity.PowderWeightUnitId);
            ViewBag.COL = entity.COL;
            ViewBag.COLUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", entity.COLUnitId);
            ViewBag.Velocity = entity.Velocity;
            ViewBag.VelocityUnitId = new SelectList(this.velocityUnits, "Id", "Abbreviation", entity.VelocityUnitId);
            ViewBag.Pressure = entity.Pressure;
            ViewBag.PressureUnitId = new SelectList(this.pressureUnits, "Id", "Abbreviation", entity.PressureUnitId);
            ViewBag.Notes = entity.Notes;

            return View(entity);
        }

        public ActionResult CartridgeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new CartridgeViewModel();
            var entity = this.cartridgeService.FindById((int)id) as Cartridge;
            var entityView = this.cartridgeViews.Where(cv => cv.Id == id).First();

            viewModel.Entity = entity;
            viewModel.EntityView = entityView;

            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

        public ActionResult LoadDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new CartridgeLoadViewModel();
            var entity = this.cartridgeLoadService.FindById((int)id) as CartridgeLoad;
            var entityView = this.cartridgeLoadViews.Where(clv => clv.Id == id).First();

            if(entity.PowderWeight != null)
                ViewBag.PowderWeight = (decimal)entity.PowderWeight / 1000m;

            viewModel.Entity = entity;
            viewModel.EntityView = entityView;

            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

        public ActionResult DeleteLoad(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new CartridgeLoadViewModel();
            var entity = this.cartridgeLoadService.FindById((int)id) as CartridgeLoad;
            var entityView = this.cartridgeLoadViews.Where(clv => clv.Id == id).First();

            if (entity == null)
            {
                return HttpNotFound();
            }

            viewModel.Entity = entity;
            viewModel.EntityView = entityView;

            return View(viewModel);
        }

        [HttpPost, ActionName("DeleteLoad")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLoadConfirmed(int id)
        {
            var entity = this.cartridgeLoadService.FindById((int)id);
            this.cartridgeLoadService.Delete(entity);
            return RedirectToAction("Index");
        }

        public ActionResult EditCartridge(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = this.cartridgeService.FindById((int)id) as Cartridge;
            var entityView = this.cartridgeViews.Where(cv => cv.Id == id).First();

            if (entity == null)
            {
                return HttpNotFound();
            }

            ViewBag.CaliberId = new SelectList(this.calibers.OfType<Caliber>(), "Id", "Name");
            ViewBag.CartridgeLoadId = new SelectList(this.cartridgeLoads.OfType<CartridgeLoad>(), "Id", "Name", entity.CartridgeLoadId);
            ViewBag.BrassId = new SelectList(this.brassViews.Where(b => b.CaliberId == entityView.CartridgeLoadViewCaliberId), "Id", "Name", entity.BrassId);
            ViewBag.PrimerId = new SelectList(this.primerViews.Where(p => p.PrimerTypeId == entityView.CartridgeLoadViewCaliberViewPrimerTypeId), "Id", "PrimerName", entity.PrimerId);
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", entity.ManufacturerId);

            return View(entity);
        }

        // POST: /Bullet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCartridge([Bind(Include = "Id,Name,CartridgeLoadId,BrassId,PrimerId,ManufacturerId,Notes")] Cartridge entity)
        {
            if (ModelState.IsValid)
            {
                this.cartridgeService.Edit(entity);
                var cartridgeLoad = (CartridgeLoad)this.cartridgeLoadService.FindById(entity.CartridgeLoadId);
                return RedirectToAction("Index", new { id = cartridgeLoad.CaliberId });
            }

            ViewBag.CaliberId = new SelectList(this.calibers.OfType<Caliber>(), "Id", "Name");
            ViewBag.CartridgeLoadId = new SelectList(this.cartridgeLoads, "Id", "Name", entity.CartridgeLoadId);
            ViewBag.BrassId = new SelectList(this.brassViews, "BrassId", "BrassName", entity.BrassId);
            ViewBag.PrimerId = new SelectList(this.primerViews, "PrimerId", "PrimerName", entity.PrimerId);
            ViewBag.ManufacturerId = new SelectList(this.manufacturers, "Id", "Name", entity.ManufacturerId);

            return View(entity);
        }

        public ActionResult EditLoad(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = (CartridgeLoad)this.cartridgeLoadService.FindById((int)id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            ViewBag.CaliberName = entity.Caliber.Name;
            ViewBag.BulletId = new SelectList(this.bulletViews.Where(b => b.CaliberViewId == entity.CaliberId) , "Id", "BulletName", entity.BulletId);
            ViewBag.PowderId = new SelectList(this.powderViews, "Id", "Name", entity.PowderId);
            ViewBag.Weight = (decimal)entity.PowderWeight / 1000m;
            ViewBag.PowderWeightUnitId = new SelectList(this.massUnits.OfType<Unit>().Where(u => u.Abbreviation == "gr."), "Id", "Abbreviation", entity.PowderWeightUnitId);
            ViewBag.COL = entity.COL;
            ViewBag.COLUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", entity.COLUnitId);
            ViewBag.Velocity = entity.Velocity;
            ViewBag.VelocityUnitId = new SelectList(this.velocityUnits, "Id", "Abbreviation", entity.VelocityUnitId);
            ViewBag.Pressure = entity.Pressure;
            ViewBag.PressureUnitId = new SelectList(this.pressureUnits, "Id", "Abbreviation", entity.PressureUnitId);
            ViewBag.Notes = entity.Notes;

            return View(entity);
        }

        // POST: /Bullet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLoad([Bind(Include = "Id,Name,CaliberId,BulletId,PowderId,PowderWeight,PowderWeightUnitId,COL,COLUnitId,Velocity,VelocityUnitId,Pressure,PressureUnitId,Notes")] CartridgeLoad entity)
        {
            if (ModelState.IsValid)
            {
                var weight = Convert.ToDecimal(Request.Form["Weight"]) * 1000m;

                entity.PowderWeight = (int)weight;
                this.cartridgeLoadService.Edit(entity);
                return RedirectToAction("LoadIndex", new { id = entity.CaliberId });
            }

            Caliber caliber = this.cartridgeLoadService.GetCalibers().Where(c => c.Id == (int)entity.CaliberId).First();
            ViewBag.CaliberId = caliber;
            ViewBag.BulletId = new SelectList(this.bulletViews, "BulletId", "BulletName", entity.BulletId);
            ViewBag.PowderId = new SelectList(this.powderViews, "Id", "Name", entity.PowderId);
            ViewBag.PowderWeight = (decimal)entity.PowderWeight / 1000m;
            ViewBag.PowderWeightUnitId = new SelectList(this.massUnits.OfType<Unit>().Where(u => u.Abbreviation == "gr."), "Id", "Abbreviation", entity.PowderWeightUnitId);
            ViewBag.COL = entity.COL;
            ViewBag.COLUnitId = new SelectList(this.lengthUnits, "Id", "Abbreviation", entity.COLUnitId);
            ViewBag.Velocity = entity.Velocity;
            ViewBag.VelocityUnitId = new SelectList(this.velocityUnits, "Id", "Abbreviation", entity.VelocityUnitId);
            ViewBag.Pressure = entity.Pressure;
            ViewBag.PressureUnitId = new SelectList(this.pressureUnits, "Id", "Abbreviation", entity.PressureUnitId);
            ViewBag.Notes = entity.Notes;

            return View(entity);
        }

        public ActionResult DeleteCartridge(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new CartridgeViewModel();
            var entity = this.cartridgeService.FindById((int)id) as Cartridge;
            var entityView = this.cartridgeViews.Where(cv => cv.Id == id).First();

            viewModel.Entity = entity;
            viewModel.EntityView = entityView;

            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

        // POST: /Bullet/Delete/5
        [HttpPost, ActionName("DeleteCartridge")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCartridgeConfirmed(int id)
        {
            var entity = this.cartridgeService.FindById((int)id);
            this.cartridgeService.Delete(entity);
            return RedirectToAction("Index");
        }


        #region Json Methods

        public JsonResult GetBullets(int caliberId)
        {
            var bullets = this.bulletViews.Where(bv => bv.CaliberViewId == caliberId).OrderBy(bv => bv.Mass).ThenBy(bv => bv.BulletName);

            var bulletList = new List<string>();
            foreach (var b in bullets)
            {
                bulletList.Add(b.Id.ToString() + ":" + b.BulletName);
            }
            return Json(bulletList);
        }

        public JsonResult GetBrasses(int cartridgeLoadId)
        {
            var cartridgeLoad = this.cartridgeLoads.OfType<CartridgeLoad>().Where(c => c.Id == cartridgeLoadId).First();
            var brasses = this.brassViews.Where(bv => bv.CaliberId == cartridgeLoad.CaliberId);

            var brassList = new List<string>();
            
            foreach (var b in brasses)
            {
                brassList.Add(b.Id.ToString() + ":" + b.BrassName);
            }
            return Json(brassList);
        }

        //public JsonResult GetBrassesByCaliber(int caliberId)
        //{
        //    var brasses = this.brassViews.Where(b => b.CaliberId == caliberId);

        //    var brassList = new List<string>();

        //    foreach (var b in brasses)
        //    {
        //        brassList.Add(b.Id.ToString() + ":" + b.BrassName);
        //    }
        //    return Json(brassList);
        //}

        public JsonResult GetCartridgeLoads(int caliberId)
        {
            var cartridgeLoads = this.cartridgeLoadViews.OfType<CartridgeLoadView>().Where(c => c.CaliberId == caliberId);

            var loadList = new List<string>();

            foreach (var cl in cartridgeLoads)
            {
                loadList.Add(cl.Id.ToString() + ":" + cl.CartridgeLoadName);
            }
            return Json(loadList);
        }

        public JsonResult GetPrimers(int cartridgeLoadId)
        {
            var cartridgeLoad = this.cartridgeLoads.OfType<CartridgeLoad>().Where(c => c.Id == cartridgeLoadId).First();
            var primers = this.primerViews.Where(p => p.PrimerTypeId == cartridgeLoad.Caliber.PrimerTypeId);

            var primerList = new List<string>();
            
            foreach (var p in primers)
            {
                primerList.Add(p.Id.ToString() + ":" + p.PrimerName);
            }
            return Json(primerList);
        }

        public JsonResult GetPrimersByCaliber(int caliberId)
        {
            var caliber = this.calibers.OfType<Caliber>().Where(c => c.Id == caliberId).First();
            var primers = this.primerViews.Where(p => p.PrimerTypeId == caliber.PrimerTypeId);

            var primerList = new List<string>();

            foreach (var p in primers)
            {
                primerList.Add(p.Id.ToString() + ":" + p.PrimerName);
            }
            return Json(primerList);
        }

        #endregion

    }
}