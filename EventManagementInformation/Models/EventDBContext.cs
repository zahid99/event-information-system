using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventManagementInformation.Models
{
    public class EventDBContext:DbContext
    {
        public EventDBContext()
            : base("EventInformationSystem")
        {
            
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventVenue> Venues { get; set; }
        public DbSet<EventInfo> EventInfos { get; set; }

    }
}