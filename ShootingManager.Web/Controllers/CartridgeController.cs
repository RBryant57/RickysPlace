using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using local.yellowcaddis.ShootingManager.Core.Abstract;
using local.yellowcaddis.ShootingManager.Core.Entities;
using local.yellowcaddis.ShootingManager.Web.Models;

namespace local.yellowcaddis.ShootingManager.Web.Controllers
{
    public class CartridgeController : Controller
    {
        private Shooting_Context db = new Shooting_Context();
        private ICartridgeRepository repository;
        private IBrassRepository brassRepository;
        private IBulletRepository bulletRepository;
        public int PageSize = 4;

        //
        // GET: /Cartridge/

        public CartridgeController(ICartridgeRepository cartridgeRepository, IBrassRepository brRepository, IBulletRepository buRepository)
        {
            this.repository = cartridgeRepository;
            this.brassRepository = brRepository;
            this.bulletRepository = buRepository;
        }

        public ViewResult List(string caliberName, int page = 1)
        {
            CartridgeListViewModel model = new CartridgeListViewModel
            {
                Cartridges = repository.Cartridges
                .Where(b => caliberName == null || b.Brass1.Caliber1.Name == caliberName)
                .OrderBy(b => b.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Cartridges.Count()
                },
                Name = caliberName
            };

            return View(model);
        }

        public ActionResult Index()
        {
            var cartridges = db.Cartridges.Include(c => c.Brass1).Include(c => c.Bullet1).Include(c => c.CartridgeLoad1).Include(c => c.Manufacturer1).Include(c => c.Powder1).Include(c => c.Primer1);
            return View(cartridges.ToList());
        }

        public ActionResult BuildCartridge(string caliberName)
        {
            return View();
        }

        //
        // GET: /Cartridge/Details/5

        public ActionResult Details(int id = 0)
        {
            Cartridge cartridge = db.Cartridges.Find(id);
            if (cartridge == null)
            {
                return HttpNotFound();
            }
            return View(cartridge);
        }

        //
        // GET: /Cartridge/Create

        public ActionResult Create()
        {
            ViewBag.Brass = new SelectList(db.Brasses, "Id", "Notes");
            ViewBag.Bullet = new SelectList(db.Bullets, "Id", "Notes");
            ViewBag.CartridgeLoad = new SelectList(db.CartridgeLoads, "Id", "Notes");
            ViewBag.Manufacturer = new SelectList(db.Manufacturers, "Id", "Name");
            ViewBag.Powder = new SelectList(db.Powders, "Id", "Name");
            ViewBag.Primer = new SelectList(db.Primers, "Id", "Notes");
            return View();
        }

        //
        // POST: /Cartridge/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cartridge cartridge)
        {
            if (ModelState.IsValid)
            {
                db.Cartridges.Add(cartridge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Brass = new SelectList(db.Brasses, "Id", "Notes", cartridge.Brass);
            ViewBag.Bullet = new SelectList(db.Bullets, "Id", "Notes", cartridge.Bullet);
            ViewBag.CartridgeLoad = new SelectList(db.CartridgeLoads, "Id", "Notes", cartridge.CartridgeLoad);
            ViewBag.Manufacturer = new SelectList(db.Manufacturers, "Id", "Name", cartridge.Manufacturer);
            ViewBag.Powder = new SelectList(db.Powders, "Id", "Name", cartridge.Powder);
            ViewBag.Primer = new SelectList(db.Primers, "Id", "Notes", cartridge.Primer);
            return View(cartridge);
        }

        //
        // GET: /Cartridge/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cartridge cartridge = db.Cartridges.Find(id);
            if (cartridge == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brass = new SelectList(db.Brasses, "Id", "Notes", cartridge.Brass);
            ViewBag.Bullet = new SelectList(db.Bullets, "Id", "Notes", cartridge.Bullet);
            ViewBag.CartridgeLoad = new SelectList(db.CartridgeLoads, "Id", "Notes", cartridge.CartridgeLoad);
            ViewBag.Manufacturer = new SelectList(db.Manufacturers, "Id", "Name", cartridge.Manufacturer);
            ViewBag.Powder = new SelectList(db.Powders, "Id", "Name", cartridge.Powder);
            ViewBag.Primer = new SelectList(db.Primers, "Id", "Notes", cartridge.Primer);
            return View(cartridge);
        }

        //
        // POST: /Cartridge/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cartridge cartridge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartridge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Brass = new SelectList(db.Brasses, "Id", "Notes", cartridge.Brass);
            ViewBag.Bullet = new SelectList(db.Bullets, "Id", "Notes", cartridge.Bullet);
            ViewBag.CartridgeLoad = new SelectList(db.CartridgeLoads, "Id", "Notes", cartridge.CartridgeLoad);
            ViewBag.Manufacturer = new SelectList(db.Manufacturers, "Id", "Name", cartridge.Manufacturer);
            ViewBag.Powder = new SelectList(db.Powders, "Id", "Name", cartridge.Powder);
            ViewBag.Primer = new SelectList(db.Primers, "Id", "Notes", cartridge.Primer);
            return View(cartridge);
        }

        //
        // GET: /Cartridge/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cartridge cartridge = db.Cartridges.Find(id);
            if (cartridge == null)
            {
                return HttpNotFound();
            }
            return View(cartridge);
        }

        //
        // POST: /Cartridge/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cartridge cartridge = db.Cartridges.Find(id);
            db.Cartridges.Remove(cartridge);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}