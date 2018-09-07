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
    public class EventsController : Controller
    {
        private EventDBContext db = new EventDBContext();

        // GET: /Events/
        public ActionResult Index()
        {
            var eventinfos = db.EventInfos.Include(e => e.EventType).Include(e => e.EventVenue);
            return View(eventinfos.ToList());
        }

        // GET: /Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInfo eventinfo = db.EventInfos.Find(id);
            if (eventinfo == null)
            {
                return HttpNotFound();
            }
            return View(eventinfo);
        }

        // GET: /Events/Create
        public ActionResult Create()
        {
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name");
            ViewBag.EventVenueId = new SelectList(db.Venues, "Id", "Name");
            return View();
        }

        // POST: /Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,EventTypeId,EventVenueId,EventName,Details,Data")] EventInfo eventinfo)
        {
            if (ModelState.IsValid)
            {
                db.EventInfos.Add(eventinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name", eventinfo.EventTypeId);
            ViewBag.EventVenueId = new SelectList(db.Venues, "Id", "Name", eventinfo.EventVenueId);
            return View(eventinfo);
        }

        // GET: /Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInfo eventinfo = db.EventInfos.Find(id);
            if (eventinfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name", eventinfo.EventTypeId);
            ViewBag.EventVenueId = new SelectList(db.Venues, "Id", "Name", eventinfo.EventVenueId);
            return View(eventinfo);
        }

        // POST: /Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,EventTypeId,EventVenueId,EventName,Details,Data")] EventInfo eventinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name", eventinfo.EventTypeId);
            ViewBag.EventVenueId = new SelectList(db.Venues, "Id", "Name", eventinfo.EventVenueId);
            return View(eventinfo);
        }

        // GET: /Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInfo eventinfo = db.EventInfos.Find(id);
            if (eventinfo == null)
            {
                return HttpNotFound();
            }
            return View(eventinfo);
        }

        // POST: /Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventInfo eventinfo = db.EventInfos.Find(id);
            db.EventInfos.Remove(eventinfo);
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
