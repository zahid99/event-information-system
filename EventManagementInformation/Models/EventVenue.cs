using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementInformation.Models
{
    public class EventVenue
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Area")]
        public int AreaId { get; set; }

         [Required(ErrorMessage = "Please Enter Venue Name")]
        [StringLength(250)]
    
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Capacity { get; set; }
        public string Image { get; set; }
        public virtual List<EventInfo> EventInfos { get; set; } 
        public virtual Area Area { get; set; }
        
    }
}