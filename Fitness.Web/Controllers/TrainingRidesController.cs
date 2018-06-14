using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessWeb.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Text;

namespace FitnessWeb.Controllers
{
    public class TrainingRidesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private HttpClient client = new HttpClient();
        private const string baseURI = "http://localhost:9050/FitnessService/";
        private const string requestURI = "api/TrainingRides/";

        // GET: TrainingRides
        public ActionResult Index()
        {
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(requestURI).Result;

            TrainingRide[] data = JsonConvert.DeserializeObject<TrainingRide[]>(response.Content.ReadAsStringAsync().Result);
            var trainingRides = data.ToList();

            //if (response.IsSuccessStatusCode)
            //{
            //    var tRides = response.Content.ReadAsStreamAsync();
            //    var tResult = tRides.Result;
            //}


            //var trainingRides = db.TrainingRides.Include(t => t.Bike).Include(t => t.Route);
            return View(trainingRides.ToList());
        }

        // GET: TrainingRides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingRide trainingRide = db.TrainingRides.Find(id);
            if (trainingRide == null)
            {
                return HttpNotFound();
            }
            return View(trainingRide);
        }

        // GET: TrainingRides/Create
        public ActionResult Create()
        {
            ViewBag.BikeId = new SelectList(db.Bikes, "Id", "Name");
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name");
            return View();
        }

        // POST: TrainingRides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,StartOdometer,EndOdometer,StartTime,EndTime,RideTimeHours,RideTimeMinutes,RideTimeSeconds,AverageHR,MaxHR,AverageCadence,ElevationGain,MaxSpeed,WindSpeed,WindDirection,Temperature,Precipitation,BikeId,RouteId,Notes")] TrainingRide trainingRide)
        {

            HttpRequestMessage request = new HttpRequestMessage();
            MediaTypeFormatter[] formatter = new MediaTypeFormatter[] { new JsonMediaTypeFormatter() };
            var content = new StringContent(trainingRide.ToString(), Encoding.UTF8, "application/json");//request.CreateContent<TrainingRide>(obj, MediaTypeHeaderValue.Parse("application/json"), formatter, new FormatterSelector());
            HttpResponseMessage response = client.PostAsync(requestURI, content).Result;
            return View(response.Content.ToString());

            if (ModelState.IsValid)
            {
                db.TrainingRides.Add(trainingRide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BikeId = new SelectList(db.Bikes, "Id", "Name", trainingRide.BikeId);
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", trainingRide.RouteId);
            return View(trainingRide);
        }

        // GET: TrainingRides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingRide trainingRide = db.TrainingRides.Find(id);
            if (trainingRide == null)
            {
                return HttpNotFound();
            }
            ViewBag.BikeId = new SelectList(db.Bikes, "Id", "Name", trainingRide.BikeId);
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", trainingRide.RouteId);
            return View(trainingRide);
        }

        // POST: TrainingRides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,StartOdometer,EndOdometer,StartTime,EndTime,RideTimeHours,RideTimeMinutes,RideTimeSeconds,AverageHR,MaxHR,AverageCadence,ElevationGain,MaxSpeed,WindSpeed,WindDirection,Temperature,Precipitation,BikeId,RouteId,Notes")] TrainingRide trainingRide)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingRide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BikeId = new SelectList(db.Bikes, "Id", "Name", trainingRide.BikeId);
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", trainingRide.RouteId);
            return View(trainingRide);
        }

        // GET: TrainingRides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingRide trainingRide = db.TrainingRides.Find(id);
            if (trainingRide == null)
            {
                return HttpNotFound();
            }
            return View(trainingRide);
        }

        // POST: TrainingRides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingRide trainingRide = db.TrainingRides.Find(id);
            db.TrainingRides.Remove(trainingRide);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }
    }
}
