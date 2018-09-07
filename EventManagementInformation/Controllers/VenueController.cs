using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventManagementInformation.Models;

namespace EventManagementInformation.Controllers
{
    public class VenueController : Controller
    {
        private EventDBContext db = new EventDBContext();

        // GET: /Venue/
        public ActionResult Index()
        {
            var venues = db.Venues.Include(e => e.Area);
            return View(venues.ToList());
        }

        // GET: /Venue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventVenue eventvenue = db.Venues.Find(id);
            if (eventvenue == null)
            {
                return HttpNotFound();
            }
            return View(eventvenue);
        }

        // GET: /Venue/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Name");
            return View();
        }

        // POST: /Venue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,AreaId,Name,Address,Capacity,Image")] EventVenue eventvenue)
        {
            if (ModelState.IsValid)
            {
                db.Venues.Add(eventvenue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Name", eventvenue.AreaId);
            return View(eventvenue);
        }

        // GET: /Venue/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventVenue eventvenue = db.Venues.Find(id);
            if (eventvenue == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Name", eventvenue.AreaId);
            return View(eventvenue);
        }

        // POST: /Venue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,AreaId,Name,Address,Capacity,Image")] EventVenue eventvenue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventvenue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Name", eventvenue.AreaId);
            return View(eventvenue);
        }

        // GET: /Venue/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventVenue eventvenue = db.Venues.Find(id);
            if (eventvenue == null)
            {
                return HttpNotFound();
            }
            return View(eventvenue);
        }

        // POST: /Venue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventVenue eventvenue = db.Venues.Find(id);
            db.Venues.Remove(eventvenue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
