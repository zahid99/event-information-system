using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementInformation.Models
{
    public class Area
    {
        //[Key]
        public int AreaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual List<EventVenue>EventVenues  { get; set; } 
    }
}