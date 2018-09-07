using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventManagementInformation.Models;
using Microsoft.Ajax.Utilities;

namespace EventManagementInformation.Controllers
{
    public class HomeController : Controller
    {

        private EventDBContext db=new EventDBContext();
        public ActionResult Index()
        {
            var area = db.Areas.ToList();
            ViewBag.AreaList = area;
            ViewBag.EventTypeList = db.EventTypes.ToList();

            //ViewBag.ConferenceList = db.EventInfos.ToList().Find(id => id.EventTypeId == 1);
            List<EventInfo> eventConference = db.EventInfos.ToList().FindAll(id => id.EventTypeId == 1);
            List<EventInfo> eventFestival = db.EventInfos.ToList().FindAll(id => id.EventTypeId == 2);
            List<EventInfo> eventPlayground = db.EventInfos.ToList().FindAll(id => id.EventTypeId == 3);
            ViewBag.ConferenceList = eventConference;
            ViewBag.PlaygroundList = eventPlayground;
            ViewBag.FestivalList = eventFestival;

            return View();
        }

        public ActionResult EventList()
        {
            var events = db.EventInfos.ToList();
            ViewBag.EventList = events;
            return View();
        } 


        public ActionResult Details(int? eventId)
        {
            if (eventId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInfo eventinfo = db.EventInfos.Find(eventId);
            if (eventinfo == null)
            {
                return HttpNotFound();
            }
            return View(eventinfo);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}