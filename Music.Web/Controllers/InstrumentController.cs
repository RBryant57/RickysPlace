using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Music.Entities.Models;
using Music.Service.Interfaces;

namespace Music.Web.Controllers
{
    public class InstrumentController : Controller
    {
        private IInstrumentService service;

        // GET: /Instrument/
        public async Task<ActionResult> Index()
        {
            return View(await this.service.GetAllAsync());
        }

        // GET: /Instrument/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var instrument = await this.service.FindByIdAsync((int)id);
            if (instrument == null)
            {
                return HttpNotFound();
            }

            return View(instrument);
        }

        // GET: /Instrument/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Instrument/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Name,Notes")] Instrument entity)
        {
            if (ModelState.IsValid)
            {
                this.service.Add(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: /Instrument/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = await this.service.FindByIdAsync((int)id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(entity);
        }

        // POST: /Instrument/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Name,Notes")] Instrument entity)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: /Instrument/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = await this.service.FindByIdAsync((int)id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(entity);
        }

        // POST: /Instrument/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var entity = await this.service.FindByIdAsync(id);
            this.service.Edit(entity);
            return RedirectToAction("Index");
        }

    }
}
