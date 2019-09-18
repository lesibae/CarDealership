using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(40)]
        public string Color { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Dealer Name")]
        public string DealerName { get; set; }
        
        public AvailabilityType availabilityType { get; set; }

        [Display(Name = "Availability Status")]
        public int AvailabilityTypeId { get; set; }
    }
}