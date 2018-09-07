using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementInformation.Models
{
    public class EventInfo
    {
        public int Id {  get; set; }
        [DisplayName("Event Type")]
        public int EventTypeId { get; set; }
        [DisplayName("Venue Name")]
        public int EventVenueId { get; set; }
        [Required(ErrorMessage = "Please Enter Event title")]
         [StringLength(250)]    
        [DisplayName("Event Name")]
        public string EventName { get; set; }
        public string Details { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]
        public DateTime Data { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual EventVenue EventVenue { get; set; }
    }
}