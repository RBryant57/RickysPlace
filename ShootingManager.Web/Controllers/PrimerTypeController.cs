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

namespace ShootingManager.Web.Controllers
{
    public class PrimerTypeController : ShootingManagerBaseController
    {
        public PrimerTypeController()
        {
            this.service = new PrimerTypeService();
        }

        public PrimerTypeController(IPrimerTypeService iService)
        {
            this.service = iService;
        }

        // GET: /PrimerType/
        public override ActionResult Index(int? id)
        {
            using (var localService = this.service as PrimerTypeService)
            {
                return View(localService.GetAll().OfType<PrimerType>().OrderBy(e => e.Name));
            }
        }

        // GET: /PrimerType/Details/5
        public override ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = this.service.FindById((int)id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(entity);
        }

        // GET: /PrimerType/Create
        public override ActionResult Create()
        {
            return View();
        }

        // POST: /PrimerType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Abbreviation,Notes")] PrimerType entity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: /PrimerType/Edit/5
        public override ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = this.service.FindById((int)id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(entity);
        }

        // POST: /PrimerType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Abbreviation,Notes")] PrimerType entity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: /PrimerType/Delete/5
        public override ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = this.service.FindById((int)id) as PrimerType;
            if (entity == null)
            {
                return HttpNotFound();
            }

            ViewBag.CanDelete = !(entity.Primers.Any() || entity.Calibers.Any());
            return View(entity);
        }


    }
}
